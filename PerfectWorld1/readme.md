# About

Read json from a database table to a file than deserialize the file to a model.

The point is, this is a perfect world were say one company exports data in a clean json format to another company. This is not always the case which is what code in the other projects is about, working with data that does not meet specifications such as property names like firstname or first.name when FirstName is expected.

## Before running

- Create a database in [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) named InsertExamples under [localdb](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16)
    - Connection string is in appsettings.json
- Run CreatePopulateInsertExample.sql