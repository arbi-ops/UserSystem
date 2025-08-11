DELETE FROM dbo.Privileges
WHERE GroupId IS NOT NULL
AND NOT EXISTS (
    SELECT 1 FROM dbo.Groups WHERE Id = GroupId
)