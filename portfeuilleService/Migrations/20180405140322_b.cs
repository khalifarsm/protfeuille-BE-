using Microsoft.EntityFrameworkCore.Migrations;
using portfeuilleService.Data;
using System;
using System.Collections.Generic;

namespace portfeuilleService.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new PortfeuilleContext())
            {
                db.seed();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
