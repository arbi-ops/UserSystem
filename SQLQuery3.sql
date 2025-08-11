SELECT * FROM dbo.Privileges p
WHERE p.GroupId IS NOT NULL
AND NOT EXISTS (
    SELECT 1 FROM dbo.Groups g WHERE g.Id = p.GroupId
)