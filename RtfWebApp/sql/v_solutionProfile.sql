CREATE VIEW V_SOLUTION_PROFILE
as
SELECT
 SOLUTIONID,
 S.TITLE AS SOLUTIONNAME,
 PROFILEID,
 P.NAME AS PROFILEANAME, 
 INTERSECTCOUNT 
FROM
(
SELECT
	SS.SOLUTIONID AS SOLUTIONID,
	PS.PROFILEID AS PROFILEID,
	COUNT(1) AS INTERSECTCOUNT
FROM DBO.SOLUTIONSSKILLS SS
INNER JOIN DBO.PROFILESKILS PS ON SS.SKILLID = PS.SKILLID
GROUP BY SS.SOLUTIONID, PS.PROFILEID
) INS
INNER JOIN DBO.SOLUTIONS S ON INS.SOLUTIONID = S.ID
INNER JOIN DBO.PROFILES P ON INS.PROFILEID = P.ID
