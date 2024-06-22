using System;
using System.Collections.Generic;
// using Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq; // Agregar esta directiva para el Logger

namespace StringManipulation.Tests // Referencia del proyecto
{
    public class StringOperationsTest // Referencia al Nombre de la case  
    {
        [Fact] // Para convertir funciòn a prueba 
        public void ConcatenateStrings()
        {
               // Crear un objeto Mock de ILogger<StringOperations>
            var mockLogger = new Mock<ILogger<StringOperations>>();

            // Arrange
              // Crear una instancia de StringOperations pasando el logger mock como argumento
            var strOperations = new StringOperations(mockLogger.Object);

            // Act
            var result = strOperations.ConcatenateStrings("Hello","Platzi"); //Se mandan los parametros esperados

            //Assert
            Assert.NotNull(result); // validar si el dato no es null
            Assert.NotEmpty(result); // validar si el dato no es vacìo
            Assert.Equal("Hello Platzi",result); // Se le informa el resultado esperado e imprime con èl el resutaldo dado.
        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Crear un objeto Mock de ILogger<StringOperations>
            var mockLogger = new Mock<ILogger<StringOperations>>();

            // Arrange
            // Crear una instancia de StringOperations pasando el logger mock como argumento
            var strOperations = new StringOperations(mockLogger.Object);

            // Act
            var result = strOperations.IsPalindrome("ama"); //Se mandan los parametros esperados

            // Assert
            Assert.True(result); // Verificar si el resultado es verdadero
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Crear un objeto Mock de ILogger<StringOperations>
            var mockLogger = new Mock<ILogger<StringOperations>>();

            // Arrange
            // Crear una instancia de StringOperations pasando el logger mock como argumento
            var strOperations = new StringOperations(mockLogger.Object);

            // Act
            var result = strOperations.IsPalindrome("Cama"); //Se mandan los parametros esperados

            // Assert
            Assert.False(result); // Verificar si el resultado es verdadero
        }

        [Fact]
        public void RemoveWhitespace()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();

            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.RemoveWhitespace("Kevin Daza");

            Assert.Equal("KevinDaza",result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();

            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.QuantintyInWords("cat",10);

            Assert.StartsWith("ten", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void GetStringLength()
        {
            
        }
    }
}