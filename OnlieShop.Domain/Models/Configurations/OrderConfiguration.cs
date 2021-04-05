using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Models.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace OnlieShop.Domain.Models.Configurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) 
        {
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.OrderDetails).WithOne(od => od.Order).HasForeignKey(o => o.OrderId);
            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

        }
    }
}
