using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class first1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    CodeDepartement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepartement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.CodeDepartement);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    CodeGrade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGrade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.CodeGrade);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    CodeGroupe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.CodeGroupe);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    CodeMatiere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMatiere = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NbreHeureCoursParSemaine = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NbreHeureTDParSemaine = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NbreHeureTPParSemaine = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.CodeMatiere);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    CodeSeance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSeance = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.CodeSeance);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateRecrutement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDepartement = table.Column<int>(type: "int", nullable: false),
                    CodeGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.CodeEnseignant);
                    table.ForeignKey(
                        name: "FK_Enseignants_Departements_CodeDepartement",
                        column: x => x.CodeDepartement,
                        principalTable: "Departements",
                        principalColumn: "CodeDepartement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enseignants_Grades_CodeGrade",
                        column: x => x.CodeGrade,
                        principalTable: "Grades",
                        principalColumn: "CodeGrade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    CodeClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClasse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodeGroupe = table.Column<int>(type: "int", nullable: false),
                    CodeDepartement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.CodeClasse);
                    table.ForeignKey(
                        name: "FK_Classes_Departements_CodeDepartement",
                        column: x => x.CodeDepartement,
                        principalTable: "Departements",
                        principalColumn: "CodeDepartement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Groupes_CodeGroupe",
                        column: x => x.CodeGroupe,
                        principalTable: "Groupes",
                        principalColumn: "CodeGroupe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeClasse = table.Column<int>(type: "int", nullable: false),
                    NumInscription = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.CodeEtudiant);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_CodeClasse",
                        column: x => x.CodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FicheAbsences",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateJour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeMatiere = table.Column<int>(type: "int", nullable: false),
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false),
                    CodeClasse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheAbsences", x => x.CodeFicheAbsence);
                    table.ForeignKey(
                        name: "FK_FicheAbsences_Classes_CodeClasse",
                        column: x => x.CodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FicheAbsences_Enseignants_CodeEnseignant",
                        column: x => x.CodeEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "CodeEnseignant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FicheAbsences_Matieres_CodeMatiere",
                        column: x => x.CodeMatiere,
                        principalTable: "Matieres",
                        principalColumn: "CodeMatiere",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FicheAbsenceSeances",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false),
                    CodeSeance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheAbsenceSeances", x => new { x.CodeFicheAbsence, x.CodeSeance });
                    table.ForeignKey(
                        name: "FK_FicheAbsenceSeances_FicheAbsences_CodeFicheAbsence",
                        column: x => x.CodeFicheAbsence,
                        principalTable: "FicheAbsences",
                        principalColumn: "CodeFicheAbsence",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FicheAbsenceSeances_Seances_CodeSeance",
                        column: x => x.CodeSeance,
                        principalTable: "Seances",
                        principalColumn: "CodeSeance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LigneFicheAbsences",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false),
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFicheAbsences", x => new { x.CodeFicheAbsence, x.CodeEtudiant });
                    table.ForeignKey(
                        name: "FK_LigneFicheAbsences_Etudiants_CodeEtudiant",
                        column: x => x.CodeEtudiant,
                        principalTable: "Etudiants",
                        principalColumn: "CodeEtudiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneFicheAbsences_FicheAbsences_CodeFicheAbsence",
                        column: x => x.CodeFicheAbsence,
                        principalTable: "FicheAbsences",
                        principalColumn: "CodeFicheAbsence",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CodeDepartement",
                table: "Classes",
                column: "CodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CodeGroupe",
                table: "Classes",
                column: "CodeGroupe");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_CodeDepartement",
                table: "Enseignants",
                column: "CodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_CodeGrade",
                table: "Enseignants",
                column: "CodeGrade");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_CodeClasse",
                table: "Etudiants",
                column: "CodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsences_CodeClasse",
                table: "FicheAbsences",
                column: "CodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsences_CodeEnseignant",
                table: "FicheAbsences",
                column: "CodeEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsences_CodeMatiere",
                table: "FicheAbsences",
                column: "CodeMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsenceSeances_CodeSeance",
                table: "FicheAbsenceSeances",
                column: "CodeSeance");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFicheAbsences_CodeEtudiant",
                table: "LigneFicheAbsences",
                column: "CodeEtudiant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FicheAbsenceSeances");

            migrationBuilder.DropTable(
                name: "LigneFicheAbsences");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "FicheAbsences");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
