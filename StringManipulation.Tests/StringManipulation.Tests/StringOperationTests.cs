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

              // Crear una instancia de StringOperations pasando el logger mock como argumento
            var strOperations = new StringOperations(mockLogger.Object);


            var result = strOperations.ConcatenateStrings("Hello","Platzi"); //Se mandan los parametros esperados


            Assert.Equal("Hello Platzi",result); // Se le informa el resultado esperado e imprime con èl el resutaldo dado.
        }
    }
}