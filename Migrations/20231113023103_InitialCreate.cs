using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuiviFitness.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exercices",
                columns: table => new
                {
                    IDExercice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomExercice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeExercice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercices", x => x.IDExercice);
                });

            migrationBuilder.CreateTable(
                name: "listeUtilisateur",
                columns: table => new
                {
                    IDUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresseEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motDePasseHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeUtilisateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    certifications = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listeUtilisateur", x => x.IDUtilisateur);
                });

            migrationBuilder.CreateTable(
                name: "donneesNutritionnelles",
                columns: table => new
                {
                    IDDonneeNutritionnelle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUtilisateur = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeRepas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlimentsConsommes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Proteines = table.Column<int>(type: "int", nullable: false),
                    Glucides = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donneesNutritionnelles", x => x.IDDonneeNutritionnelle);
                    table.ForeignKey(
                        name: "FK_donneesNutritionnelles_listeUtilisateur_IDUtilisateur",
                        column: x => x.IDUtilisateur,
                        principalTable: "listeUtilisateur",
                        principalColumn: "IDUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "progressions",
                columns: table => new
                {
                    IDProgression = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUtilisateur = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeProgression = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsProgression = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_progressions", x => x.IDProgression);
                    table.ForeignKey(
                        name: "FK_progressions_listeUtilisateur_IDUtilisateur",
                        column: x => x.IDUtilisateur,
                        principalTable: "listeUtilisateur",
                        principalColumn: "IDUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recommendations",
                columns: table => new
                {
                    IDRecommandation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUtilisateur = table.Column<int>(type: "int", nullable: false),
                    DateRecommandation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeRecommandation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContenuRecommandation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recommendations", x => x.IDRecommandation);
                    table.ForeignKey(
                        name: "FK_recommendations_listeUtilisateur_IDUtilisateur",
                        column: x => x.IDUtilisateur,
                        principalTable: "listeUtilisateur",
                        principalColumn: "IDUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seances",
                columns: table => new
                {
                    IDSeance = table.Column<int>(type: "int", nullable: false),
                    IDUtilisateur = table.Column<int>(type: "int", nullable: false),
                    DateHeure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seances", x => x.IDSeance);
                    table.ForeignKey(
                        name: "FK_seances_listeUtilisateur_IDSeance",
                        column: x => x.IDSeance,
                        principalTable: "listeUtilisateur",
                        principalColumn: "IDUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "details",
                columns: table => new
                {
                    IDDetailSeance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSéance = table.Column<int>(type: "int", nullable: false),
                    IDExercice = table.Column<int>(type: "int", nullable: false),
                    NombreSeries = table.Column<int>(type: "int", nullable: false),
                    RepetitionsParSerie = table.Column<int>(type: "int", nullable: false),
                    PoidsUtilise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details", x => x.IDDetailSeance);
                    table.ForeignKey(
                        name: "FK_details_exercices_IDExercice",
                        column: x => x.IDExercice,
                        principalTable: "exercices",
                        principalColumn: "IDExercice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_details_seances_IDSéance",
                        column: x => x.IDSéance,
                        principalTable: "seances",
                        principalColumn: "IDSeance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_details_IDExercice",
                table: "details",
                column: "IDExercice");

            migrationBuilder.CreateIndex(
                name: "IX_details_IDSéance",
                table: "details",
                column: "IDSéance");

            migrationBuilder.CreateIndex(
                name: "IX_donneesNutritionnelles_IDUtilisateur",
                table: "donneesNutritionnelles",
                column: "IDUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_progressions_IDUtilisateur",
                table: "progressions",
                column: "IDUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_recommendations_IDUtilisateur",
                table: "recommendations",
                column: "IDUtilisateur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "details");

            migrationBuilder.DropTable(
                name: "donneesNutritionnelles");

            migrationBuilder.DropTable(
                name: "progressions");

            migrationBuilder.DropTable(
                name: "recommendations");

            migrationBuilder.DropTable(
                name: "exercices");

            migrationBuilder.DropTable(
                name: "seances");

            migrationBuilder.DropTable(
                name: "listeUtilisateur");
        }
    }
}
