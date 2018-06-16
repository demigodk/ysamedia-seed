using Microsoft.EntityFrameworkCore.Migrations;

namespace ysamedia.Data.Migrations
{
    public partial class _2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "tblUserToken");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "tblUser");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "tblUserRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "tblUserLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "tblUserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "tblRole");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "tblRoleClaim");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "tblUserRole",
                newName: "IX_tblUserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "tblUserLogin",
                newName: "IX_tblUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "tblUserClaim",
                newName: "IX_tblUserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "tblRoleClaim",
                newName: "IX_tblRoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserToken",
                table: "tblUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserRole",
                table: "tblUserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserLogin",
                table: "tblUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserClaim",
                table: "tblUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRole",
                table: "tblRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoleClaim",
                table: "tblRoleClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRoleClaim_tblRole_RoleId",
                table: "tblRoleClaim",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserClaim_tblUser_UserId",
                table: "tblUserClaim",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserLogin_tblUser_UserId",
                table: "tblUserLogin",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRole_tblRole_RoleId",
                table: "tblUserRole",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRole_tblUser_UserId",
                table: "tblUserRole",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserToken_tblUser_UserId",
                table: "tblUserToken",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRoleClaim_tblRole_RoleId",
                table: "tblRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserClaim_tblUser_UserId",
                table: "tblUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserLogin_tblUser_UserId",
                table: "tblUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRole_tblRole_RoleId",
                table: "tblUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRole_tblUser_UserId",
                table: "tblUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserToken_tblUser_UserId",
                table: "tblUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserToken",
                table: "tblUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserRole",
                table: "tblUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserLogin",
                table: "tblUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserClaim",
                table: "tblUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoleClaim",
                table: "tblRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRole",
                table: "tblRole");

            migrationBuilder.RenameTable(
                name: "tblUserToken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "tblUserRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "tblUserLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "tblUserClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "tblUser",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "tblRoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "tblRole",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_tblRoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
