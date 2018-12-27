namespace SertzHir.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStoredProcedureScripts_Added : DbMigration
    {
        public override void Up()
        {
            
            Sql(StoredProcedureScripts);

        }

        public override void Down()
        {
        }

        private const string StoredProcedureScripts = @"
        -- =============================================
        -- Author:		<Author,,Name>
        -- Create date: <Create Date,,>
        -- Description:	<Description,,>
        -- =============================================
        CREATE PROCEDURE [dbo].[GetAllPeople]
	        
        AS
        BEGIN
	        -- SET NOCOUNT ON added to prevent extra result sets from
	        -- interfering with SELECT statements.
	        SET NOCOUNT ON;

            -- Insert statements for procedure here
	        SELECT * from people
        END
        GO
        
        -- =============================================
        -- Author:		Peevee Pascual
        -- Create date: 12/23/2018
        -- Description:	Insert a Person record
        -- =============================================
        CREATE PROCEDURE [dbo].[uspPersonInsert]
	        
	        @last_name varchar(50)
	        ,@first_name varchar(50)
	        ,@gender char(1)
	        ,@dob DateTime
	        ,@state_id int
	        
        AS
        BEGIN
	        DECLARE @IdentityId int
	        
	        SET NOCOUNT OFF;

	        INSERT INTO People(last_name,first_name,gender,dob,state_id)
	        VALUES(@last_name,@first_name,@gender,@dob,@state_id);

	        SELECT CAST(SCOPE_IDENTITY()AS int) AS IdentityId
        END
        GO

        SET QUOTED_IDENTIFIER ON
        GO

        -- =============================================
        -- Author:		Peevee Pascual
        -- Create date: 12/23/2018
        -- Description:	Search a Person record
        -- =============================================
        CREATE PROCEDURE [dbo].[uspPersonSearch]
	        @last_name varchar(50)
	        ,@first_name varchar(50)
	        
        AS
        BEGIN
	        
	        SET NOCOUNT ON;

	        SELECT person_id,last_name,first_name,gender, dob,sta.state_id,sta.state_code
	        FROM People peo
	        INNER JOIN States sta ON peo.state_id = sta.state_id
	        WHERE last_name LIKE '%'+ @last_name +'%' AND first_name LIKE '%'+ @first_name +'%' 
	        ORDER BY last_name ASC
	        
        END
        GO

        -- =============================================
        -- Author:		Peevee Pascual
        -- Create date: 12/23/2018
        -- Description:	Update a Person record
        -- =============================================
        CREATE PROCEDURE [dbo].[uspPersonUpdate]
	        @person_id int
	        ,@last_name varchar(50)
	        ,@first_name varchar(50)
	        ,@gender char(1)
	        ,@dob DateTime
	        ,@state_id int
        AS
        BEGIN
	        DECLARE @IdentityId int
	        
	        SET NOCOUNT OFF;

	        UPDATE People SET
	        last_name=@last_name
	        ,first_name=@first_name
	        ,gender=@gender
	        ,dob=@dob
	        ,state_id=@state_id
	        WHERE person_id=@person_id

	        SELECT person_id, last_name, first_name, gender, dob, state_id 
	        FROM people
	        WHERE person_id=@person_id

        END
        GO

        -- =============================================
        -- Author:		Peevee Pascual
        -- Create date: 12/23/2018
        -- Description:	List all States record
        -- =============================================
        CREATE PROCEDURE [dbo].[uspStatesList]
	        
        AS
        BEGIN
	        -- SET NOCOUNT ON added to prevent extra result sets from
	        -- interfering with SELECT statements.
	        SET NOCOUNT ON;

            -- Insert statements for procedure here
	        SELECT state_id, state_code 
	        FROM States
	        ORDER BY state_code ASC
        END
        GO



    ";
    }
}
