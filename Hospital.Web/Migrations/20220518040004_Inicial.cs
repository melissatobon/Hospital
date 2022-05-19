using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Web.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AntecedentsAllergics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentsAllergics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentsFamily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentsFamily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentsStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentsStaffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentsSurgical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentsSurgical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Egresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NurseNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Process = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VitalSigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Temperature = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    Fc = table.Column<int>(type: "int", nullable: false),
                    Pas = table.Column<int>(type: "int", nullable: false),
                    Pad = table.Column<int>(type: "int", nullable: false),
                    Fr = table.Column<int>(type: "int", nullable: false),
                    Spo2 = table.Column<int>(type: "int", nullable: false),
                    Glucometry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DateBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nurse = table.Column<bool>(type: "bit", nullable: false),
                    Medical = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AntecedentAllergicId = table.Column<int>(type: "int", nullable: true),
                    AntecedentFamiliarId = table.Column<int>(type: "int", nullable: true),
                    AntecedentStaffId = table.Column<int>(type: "int", nullable: true),
                    AntecedentSurgicalId = table.Column<int>(type: "int", nullable: true),
                    ContactPatientId = table.Column<int>(type: "int", nullable: true),
                    EgressId = table.Column<int>(type: "int", nullable: true),
                    LaboratoryExamId = table.Column<int>(type: "int", nullable: true),
                    MedicalNoteId = table.Column<int>(type: "int", nullable: true),
                    NurseNoteId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    VitalSignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AntecedentsAllergics_AntecedentAllergicId",
                        column: x => x.AntecedentAllergicId,
                        principalTable: "AntecedentsAllergics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AntecedentsFamily_AntecedentFamiliarId",
                        column: x => x.AntecedentFamiliarId,
                        principalTable: "AntecedentsFamily",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AntecedentsStaffs_AntecedentStaffId",
                        column: x => x.AntecedentStaffId,
                        principalTable: "AntecedentsStaffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AntecedentsSurgical_AntecedentSurgicalId",
                        column: x => x.AntecedentSurgicalId,
                        principalTable: "AntecedentsSurgical",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_ContactPatients_ContactPatientId",
                        column: x => x.ContactPatientId,
                        principalTable: "ContactPatients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Egresses_EgressId",
                        column: x => x.EgressId,
                        principalTable: "Egresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_LaboratoryExams_LaboratoryExamId",
                        column: x => x.LaboratoryExamId,
                        principalTable: "LaboratoryExams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_MedicalNotes_MedicalNoteId",
                        column: x => x.MedicalNoteId,
                        principalTable: "MedicalNotes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_NurseNotes_NurseNoteId",
                        column: x => x.NurseNoteId,
                        principalTable: "NurseNotes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_VitalSigns_VitalSignId",
                        column: x => x.VitalSignId,
                        principalTable: "VitalSigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentsAllergics_Name",
                table: "AntecedentsAllergics",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentsFamily_Name",
                table: "AntecedentsFamily",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentsStaffs_Name",
                table: "AntecedentsStaffs",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentsSurgical_Name",
                table: "AntecedentsSurgical",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPatients_Id",
                table: "ContactPatients",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Egresses_Id",
                table: "Egresses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Id",
                table: "Employees",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryExams_Id",
                table: "LaboratoryExams",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalNotes_Id",
                table: "MedicalNotes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseNotes_Id",
                table: "NurseNotes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AntecedentAllergicId",
                table: "Patients",
                column: "AntecedentAllergicId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AntecedentFamiliarId",
                table: "Patients",
                column: "AntecedentFamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AntecedentStaffId",
                table: "Patients",
                column: "AntecedentStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AntecedentSurgicalId",
                table: "Patients",
                column: "AntecedentSurgicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ContactPatientId",
                table: "Patients",
                column: "ContactPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Document",
                table: "Patients",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EgressId",
                table: "Patients",
                column: "EgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LaboratoryExamId",
                table: "Patients",
                column: "LaboratoryExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalNoteId",
                table: "Patients",
                column: "MedicalNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NurseNoteId",
                table: "Patients",
                column: "NurseNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_OrderId",
                table: "Patients",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_VitalSignId",
                table: "Patients",
                column: "VitalSignId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VitalSigns_Id",
                table: "VitalSigns",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AntecedentsAllergics");

            migrationBuilder.DropTable(
                name: "AntecedentsFamily");

            migrationBuilder.DropTable(
                name: "AntecedentsStaffs");

            migrationBuilder.DropTable(
                name: "AntecedentsSurgical");

            migrationBuilder.DropTable(
                name: "ContactPatients");

            migrationBuilder.DropTable(
                name: "Egresses");

            migrationBuilder.DropTable(
                name: "LaboratoryExams");

            migrationBuilder.DropTable(
                name: "MedicalNotes");

            migrationBuilder.DropTable(
                name: "NurseNotes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "VitalSigns");
        }
    }
}
