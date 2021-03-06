CREATE VIEW [dbo].[V_EMPLOYEE_OBJECTIVITY]
AS
    WITH tmp
    AS
    (
        SELECT 
            EmployeeId AS [EmployeeId], 
            ABS(AVG(Rate) - STDEV(Rate)) AS [Diff]
        FROM 
            AuthorRatings ar
            JOIN Employees e ON ar.EmployeeId = e.ID
            LEFT JOIN ProfileSkils ps ON e.ProfileId = ps.ProfileId AND ps.SkillId = ar.SkillId
        WHERE
            ps.SkillId IS NULL
        GROUP BY EmployeeId
    )
    SELECT tmp.EmployeeId,
           ISNULL(CASE 
            WHEN [Diff] < 1 THEN 1
            WHEN [Diff] < 2 THEN 0.8
            WHEN [Diff] < 3 THEN 0.6
            WHEN [Diff] < 4 THEN 0.4
            WHEN [Diff] < 5 THEN 0.2
           END, 1) AS [Objectivity]
    FROM 
        tmp
GO