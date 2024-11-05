using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Norebase_Like_Feature_Challenge.Infrastructure.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DateCreated", "LikeCount", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7895), 5, "Exploring the Future of Cryptocurrency in Nigeria" },
                    { 2, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7911), 5, "IoT: Transforming Smart Homes in Urban Nigeria" },
                    { 3, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7912), 5, "Cloud Computing: A Game Changer for Nigerian Startups" },
                    { 4, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7913), 5, "Artificial Intelligence and its Impact on Nigeria’s Economy" },
                    { 5, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7947), 5, "The Role of Blockchain Technology in Enhancing Security" },
                    { 6, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7948), 5, "Cybersecurity Trends: Safeguarding Data in the Digital Age" },
                    { 7, new DateTime(2024, 11, 5, 7, 22, 7, 56, DateTimeKind.Local).AddTicks(7949), 5, "The Rise of Fintech: Innovations Shaping the Banking Sector" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chinedu Okafor" },
                    { 2, "Amaka Nwankwo" },
                    { 3, "Emeka Ibe" },
                    { 4, "Ngozi Nwosu" },
                    { 5, "Tunde Adebayo" },
                    { 6, "Sola Bakare" },
                    { 7, "Adaobi Eze" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "ArticleId", "LikedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8123), 1 },
                    { 2, 2, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8124), 1 },
                    { 3, 3, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8125), 1 },
                    { 4, 4, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8126), 1 },
                    { 5, 5, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8126), 1 },
                    { 6, 1, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8127), 2 },
                    { 7, 3, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8128), 2 },
                    { 8, 4, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8129), 2 },
                    { 9, 5, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8129), 2 },
                    { 10, 6, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8130), 2 },
                    { 11, 1, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8131), 3 },
                    { 12, 2, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8131), 3 },
                    { 13, 3, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8132), 3 },
                    { 14, 4, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8132), 3 },
                    { 15, 5, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8133), 3 },
                    { 16, 7, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8134), 3 },
                    { 17, 1, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8134), 4 },
                    { 18, 2, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8135), 4 },
                    { 19, 6, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8136), 4 },
                    { 20, 7, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8136), 4 },
                    { 21, 5, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8137), 4 },
                    { 22, 3, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8138), 5 },
                    { 23, 4, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8139), 5 },
                    { 24, 6, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8139), 5 },
                    { 25, 1, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8140), 5 },
                    { 26, 7, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8141), 5 },
                    { 27, 2, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8141), 6 },
                    { 28, 3, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8142), 6 },
                    { 29, 4, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8143), 6 },
                    { 30, 5, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8143), 6 },
                    { 31, 6, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8144), 6 },
                    { 32, 7, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8144), 6 },
                    { 33, 1, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8145), 7 },
                    { 34, 2, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8147), 7 },
                    { 35, 5, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8147), 7 },
                    { 36, 6, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8148), 7 },
                    { 37, 7, new DateTime(2024, 11, 5, 6, 22, 7, 56, DateTimeKind.Utc).AddTicks(8149), 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ArticleId",
                table: "Likes",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                table: "Likes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ArticleId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
