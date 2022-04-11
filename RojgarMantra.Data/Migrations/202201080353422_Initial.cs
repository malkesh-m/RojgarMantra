namespace RojgarMantra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        IsPostGraduationCourseOrDegree = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExceptionLoggers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(maxLength: 200, storeType: "nvarchar"),
                        Type = c.String(maxLength: 200, storeType: "nvarchar"),
                        ControllerName = c.String(maxLength: 200, storeType: "nvarchar"),
                        ExceptionStackTrace = c.String(maxLength: 200, storeType: "nvarchar"),
                        LogTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobAlertDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Designation = c.String(maxLength: 100, storeType: "nvarchar"),
                        Location = c.String(maxLength: 200, storeType: "nvarchar"),
                        YearOfExperience = c.Int(nullable: false),
                        NameOfJobAlert = c.String(maxLength: 150, storeType: "nvarchar"),
                        JobCategory = c.String(maxLength: 150, storeType: "nvarchar"),
                        WorkExperience = c.Int(nullable: false),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        Role = c.String(maxLength: 150, storeType: "nvarchar"),
                        Skills = c.String(maxLength: 200, storeType: "nvarchar"),
                        NoticePeriod = c.String(maxLength: 200, storeType: "nvarchar"),
                        ExpectedCTCLac = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpectedCTCThousand = c.Int(nullable: false),
                        NegotiableExpectedCTC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FirstName = c.String(maxLength: 100, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 100, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Country = c.String(maxLength: 100, storeType: "nvarchar"),
                        State = c.String(maxLength: 100, storeType: "nvarchar"),
                        City = c.String(maxLength: 100, storeType: "nvarchar"),
                        PermanentLocation = c.String(maxLength: 200, storeType: "nvarchar"),
                        CurrentAddress = c.String(maxLength: 200, storeType: "nvarchar"),
                        Status = c.String(maxLength: 100, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 200, storeType: "nvarchar"),
                        SecurityStamp = c.String(maxLength: 200, storeType: "nvarchar"),
                        PhoneNumber = c.String(maxLength: 200, storeType: "nvarchar"),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(maxLength: 200, storeType: "nvarchar"),
                        ClaimValue = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        CreatedBy = c.String(maxLength: 200, storeType: "nvarchar"),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedBy = c.String(maxLength: 200, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        PersonalContactNumber = c.Double(nullable: false),
                        CompanyName = c.String(maxLength: 150, storeType: "nvarchar"),
                        Website = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        JobType = c.String(maxLength: 150, storeType: "nvarchar"),
                        JobStartDate = c.DateTime(precision: 0),
                        JobTitle = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        MinWorkExperience = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxWorkExperience = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinAnnualSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxAnnualSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContactNumber = c.Double(),
                        NumberOfOpenings = c.Int(nullable: false),
                        LocationOfJob = c.String(maxLength: 200, storeType: "nvarchar"),
                        Skills = c.String(maxLength: 200, storeType: "nvarchar"),
                        JobEndDate = c.DateTime(precision: 0),
                        PostEndDate = c.DateTime(precision: 0),
                        JobDescription = c.String(maxLength: 200, storeType: "nvarchar"),
                        HSC = c.Boolean(nullable: false),
                        SSC = c.Boolean(nullable: false),
                        DegreeId = c.Int(nullable: false),
                        PostDegreeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Degrees", t => t.PostDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DegreeId)
                .Index(t => t.PostDegreeId);
            
            CreateTable(
                "dbo.PlacementDrives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        JobTitle = c.String(maxLength: 150, storeType: "nvarchar"),
                        CompanyName = c.String(maxLength: 150, storeType: "nvarchar"),
                        NumberOfVacancies = c.Int(nullable: false),
                        FromDate = c.DateTime(precision: 0),
                        ToDate = c.DateTime(precision: 0),
                        Package = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DegreeId = c.Int(nullable: false),
                        SelectionProcessId = c.Int(nullable: false),
                        PrimaryCoOrdinatorName = c.String(maxLength: 200, storeType: "nvarchar"),
                        CoOrdinatorNumber = c.Double(nullable: false),
                        CoOrdinatorAlternateNumber = c.Double(nullable: false),
                        Venue = c.String(maxLength: 200, storeType: "nvarchar"),
                        EligibleCoursesCertifications = c.String(maxLength: 200, storeType: "nvarchar"),
                        JobLocation = c.String(maxLength: 200, storeType: "nvarchar"),
                        Timings = c.String(maxLength: 150, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.SelectionProcesses", t => t.SelectionProcessId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DegreeId)
                .Index(t => t.SelectionProcessId);
            
            CreateTable(
                "dbo.SelectionProcesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RazorpayDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactNo = c.String(maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        Password = c.String(maxLength: 200, storeType: "nvarchar"),
                        AccountType = c.String(maxLength: 200, storeType: "nvarchar"),
                        AccountNo = c.String(maxLength: 200, storeType: "nvarchar"),
                        VisibleOnApp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ScheduleWebinars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Title = c.String(maxLength: 100, storeType: "nvarchar"),
                        Date = c.DateTime(precision: 0),
                        PresenterName = c.String(maxLength: 150, storeType: "nvarchar"),
                        PresenterEmail = c.String(maxLength: 200, storeType: "nvarchar"),
                        PresenterContactNumber = c.Double(),
                        WorkExperience = c.Int(nullable: false),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        PhysicalVirtual = c.String(maxLength: 200, storeType: "nvarchar"),
                        VirtualLink = c.String(maxLength: 200, storeType: "nvarchar"),
                        StartTime = c.DateTime(precision: 0),
                        EndTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SMSDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 200, storeType: "nvarchar"),
                        Password = c.String(maxLength: 200, storeType: "nvarchar"),
                        SenderName = c.String(maxLength: 200, storeType: "nvarchar"),
                        Url = c.String(maxLength: 200, storeType: "nvarchar"),
                        Credit = c.String(maxLength: 150, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SMSHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MobileNo = c.String(maxLength: 150, storeType: "nvarchar"),
                        TypeOfSMS = c.String(maxLength: 200, storeType: "nvarchar"),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SMTPDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Host = c.String(maxLength: 150, storeType: "nvarchar"),
                        UserName = c.String(maxLength: 150, storeType: "nvarchar"),
                        Password = c.String(maxLength: 200, storeType: "nvarchar"),
                        Port = c.String(maxLength: 150, storeType: "nvarchar"),
                        SenderName = c.String(maxLength: 150, storeType: "nvarchar"),
                        SenderEmail = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemplateDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150, storeType: "nvarchar"),
                        Subject = c.String(maxLength: 200, storeType: "nvarchar"),
                        Type = c.String(maxLength: 200, storeType: "nvarchar"),
                        Body = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEmployers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        ContactName = c.String(maxLength: 200, storeType: "nvarchar"),
                        CompanyName = c.String(maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        ContactNumber = c.Double(nullable: false),
                        CompanyLink = c.String(maxLength: 200, storeType: "nvarchar"),
                        Address = c.String(maxLength: 250, storeType: "nvarchar"),
                        DesignationId = c.Int(nullable: false),
                        WorkExperience = c.Int(nullable: false),
                        CompanyLogo = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.UserJobSeekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        UserName = c.String(maxLength: 200, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 100, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        MarriedStatus = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Gender = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        DateOfBirth = c.DateTime(nullable: false, precision: 0),
                        PhysicallyChallenged = c.Boolean(nullable: false),
                        Email = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        ContactNumber = c.Double(nullable: false),
                        AlternateContactNumber = c.Double(nullable: false),
                        CountryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        PermanentLocation = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        PrefferredLocation = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        CurrentAddress = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        CompanyName = c.String(maxLength: 100, storeType: "nvarchar"),
                        RoleId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        TotalExperience = c.String(maxLength: 100, storeType: "nvarchar"),
                        Skills = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CurrentCTCLac = c.String(maxLength: 100, storeType: "nvarchar"),
                        CurrentCTCThousand = c.String(maxLength: 100, storeType: "nvarchar"),
                        ExpectedCurrentCTCThousand = c.String(maxLength: 100, storeType: "nvarchar"),
                        ExpectedCurrentCTCLac = c.String(maxLength: 100, storeType: "nvarchar"),
                        NegotiableExpectedCTC = c.String(maxLength: 100, storeType: "nvarchar"),
                        NoticePeriod = c.String(maxLength: 100, storeType: "nvarchar"),
                        NegotiableNoticePeriod = c.Boolean(nullable: false),
                        PrevCompanyName = c.String(maxLength: 100, storeType: "nvarchar"),
                        From = c.DateTime(nullable: false, precision: 0),
                        To = c.DateTime(nullable: false, precision: 0),
                        Experience = c.Int(nullable: false),
                        SSCMarks = c.Int(nullable: false),
                        SSCCompletionYear = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        HSCMarks = c.Int(nullable: false),
                        HSCCompletionYear = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        DegreeNameId = c.Int(nullable: false),
                        PostDegreeNameId = c.Int(nullable: false),
                        GraduationMarks = c.Int(nullable: false),
                        GraduationCompletionYear = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        GraduationCompletionInstituteUniversity = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        PostGraduationMarks = c.Int(nullable: false),
                        PostGraduationCompletionYear = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        PostGraduationCompletionInstituteUniversity = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        CourseName = c.String(maxLength: 100, storeType: "nvarchar"),
                        CourseCompletionDuration = c.String(maxLength: 100, storeType: "nvarchar"),
                        SelectLanguage = c.String(maxLength: 100, storeType: "nvarchar"),
                        Read = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Speak = c.Boolean(nullable: false),
                        Resume = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Degrees", t => t.DegreeNameId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Degrees", t => t.PostDegreeNameId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CountryId)
                .Index(t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.RoleId)
                .Index(t => t.DesignationId)
                .Index(t => t.DegreeNameId)
                .Index(t => t.PostDegreeNameId);
            
            CreateTable(
                "dbo.UserTrainingInstitutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        TrainingInstituteName = c.String(maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        ContactNumber = c.Double(nullable: false),
                        CompanyLink = c.String(maxLength: 200, storeType: "nvarchar"),
                        Address = c.String(maxLength: 250, storeType: "nvarchar"),
                        DesignationId = c.Int(nullable: false),
                        WorkExperience = c.Int(nullable: false),
                        TrainingInstituteLogo = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTrainingInstitutes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserTrainingInstitutes", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.UserJobSeekers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserJobSeekers", "StateId", "dbo.States");
            DropForeignKey("dbo.UserJobSeekers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserJobSeekers", "PostDegreeNameId", "dbo.Degrees");
            DropForeignKey("dbo.UserJobSeekers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.UserJobSeekers", "DegreeNameId", "dbo.Degrees");
            DropForeignKey("dbo.UserJobSeekers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserJobSeekers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.UserEmployers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEmployers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.ScheduleWebinars", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PlacementDrives", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PlacementDrives", "SelectionProcessId", "dbo.SelectionProcesses");
            DropForeignKey("dbo.PlacementDrives", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.JobDetails", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobDetails", "PostDegreeId", "dbo.Degrees");
            DropForeignKey("dbo.JobDetails", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.JobAlertDetails", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.UserTrainingInstitutes", new[] { "DesignationId" });
            DropIndex("dbo.UserTrainingInstitutes", new[] { "UserId" });
            DropIndex("dbo.UserJobSeekers", new[] { "PostDegreeNameId" });
            DropIndex("dbo.UserJobSeekers", new[] { "DegreeNameId" });
            DropIndex("dbo.UserJobSeekers", new[] { "DesignationId" });
            DropIndex("dbo.UserJobSeekers", new[] { "RoleId" });
            DropIndex("dbo.UserJobSeekers", new[] { "CityId" });
            DropIndex("dbo.UserJobSeekers", new[] { "StateId" });
            DropIndex("dbo.UserJobSeekers", new[] { "CountryId" });
            DropIndex("dbo.UserJobSeekers", new[] { "UserId" });
            DropIndex("dbo.UserEmployers", new[] { "DesignationId" });
            DropIndex("dbo.UserEmployers", new[] { "UserId" });
            DropIndex("dbo.ScheduleWebinars", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PlacementDrives", new[] { "SelectionProcessId" });
            DropIndex("dbo.PlacementDrives", new[] { "DegreeId" });
            DropIndex("dbo.PlacementDrives", new[] { "UserId" });
            DropIndex("dbo.JobDetails", new[] { "PostDegreeId" });
            DropIndex("dbo.JobDetails", new[] { "DegreeId" });
            DropIndex("dbo.JobDetails", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.JobAlertDetails", new[] { "UserId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Districts", new[] { "StateId" });
            DropIndex("dbo.Cities", new[] { "DistrictId" });
            DropTable("dbo.UserTrainingInstitutes");
            DropTable("dbo.UserJobSeekers");
            DropTable("dbo.UserEmployers");
            DropTable("dbo.TemplateDetails");
            DropTable("dbo.SMTPDetails");
            DropTable("dbo.SMSHistories");
            DropTable("dbo.SMSDetails");
            DropTable("dbo.ScheduleWebinars");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.RazorpayDetails");
            DropTable("dbo.SelectionProcesses");
            DropTable("dbo.PlacementDrives");
            DropTable("dbo.JobDetails");
            DropTable("dbo.JobCategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.JobAlertDetails");
            DropTable("dbo.ExceptionLoggers");
            DropTable("dbo.Designations");
            DropTable("dbo.Degrees");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Districts");
            DropTable("dbo.Cities");
        }
    }
}
