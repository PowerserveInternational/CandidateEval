select 
    [Supervisee].ID AS [Supervisee.ID],
    [Supervisee].UserName AS [Supervisee.UserName],
    [SuperVisee].[Status] AS [Supervisee.Status],
    [SuperVisee].[FirstName] AS [Supervisee.FirstName],
    [SuperVisee].[LastName] AS [Supervisee.LastName],
    [SuperVisee].Lat AS [Supervisee.Lat],
    [SuperVisee].Lng AS [Supervisee.Lng]
from Supervisee