using MFETaskBackend.Controllers;
using MFETaskBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class CartControllerTests
    {
        

        [Fact]
        public void AddToCart_ReturnsOkResult_WithAddedProduct()
        {
            // Arrange
            var controller = new CartController();
            var productToAdd = new Product { Id = "3", Title = "Product 3", Price = "30", Description = "Description 3", Category = "Category 3", Image = "Image 3", Rating = new Rating { Rate = "4.2", Count = "150" } };

            // Act
            var result = controller.AddToCart(productToAdd);

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Contains(productToAdd, CartController.cartItems);
        }

        [Fact]
        public void RemoveFromCart_ReturnsOkResult_WithRemovedProduct()
        {
            // Arrange
            var controller = new CartController();
            var productToRemove = new Product { Id = "7", Title = "Product 1", Price = "10", Description = "Description 1", Category = "Category 1", Image = "Image 1", Rating = new Rating { Rate = "4.5", Count = "100" } };
            CartController.cartItems.Add(productToRemove);

            // Act
            var result = controller.RemoveFromCart("7");

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.DoesNotContain(productToRemove, CartController.cartItems);
        }

        [Fact]
        public void AddToCart_ReturnsBadRequest_WhenProductIsNull()
        {
            // Arrange
            var controller = new CartController();

            // Act
            var result = controller.AddToCart(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        
        [Fact]
        public void RemoveFromCart_ReturnsNotFound_WhenProductNotFound()
        {
            // Arrange
            var controller = new CartController();

            // Act
            var result = controller.RemoveFromCart("5");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}