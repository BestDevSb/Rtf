CREATE VIEW V_EMPLOYEE_PROFILE_INTERSECT
as
SELECT
e1.Id as EmployeeAId,
e2.Id,
e2.Name,
ISNULL(et.TOTALRATE, 0) as TOTALRATE,
ISNULL(et.TOTALWEIGHT, 0) as TOTALWEIGHT,
pins.INTERSECTCOUNT
FROM dbo.V_INTERSECT_PROFILES pins 
INNER JOIN dbo.Employees e1 on pins.ProfileA = e1.ProfileId
INNER JOIN dbo.Employees e2 on pins.ProfileB = e2.ProfileId
LEFT JOIN dbo.V_Employee_Totals et on e2.Id = et.EMPLOYEEID
