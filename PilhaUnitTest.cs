using System;
using Xunit;
using Xunit.Sdk;

namespace XPilha
{
    public class PilhaUnitTest
    {
        private Pilha pilha;
        public PilhaUnitTest()
        {
            /*
            * Arrange - � aqui que voc� normalmente prepara tudo
            * para o teste, em outras palavras, prepara a cena para testar 
            * (criar os objetos e configur�-los conforme necess�rio)                                     
           */
            pilha = new Pilha(10);
        }

        [Fact]
        public void Pilha_Vazia()
        {                      
            /*
             * Assert - Esta � a parte final do teste em que comparamos 
             * o que esperamos que aconte�a com o resultado real da execu��o do m�todo de teste                     
             */
            Assert.True(pilha.EstaVazia());
            Assert.Equal(0, pilha.Tamanho());
        }

        [Fact]
        public void EmpilhaUmElemento()
        {            
            /*
             * Act - � onde o m�todo que estamos testando ser� executado
             */
            pilha.Empilha("primeiro");

            Assert.False(pilha.EstaVazia());
            Assert.Equal(1, pilha.Tamanho());
            Assert.Equal("primeiro", pilha.Topo());
        }

        [Fact]
        public void EmpilhaDoisElementos()
        {
            pilha.Empilha("primeiro");
            Assert.Equal("primeiro", pilha.Topo());

            pilha.Empilha("segundo");
            Assert.Equal("segundo", pilha.Topo());            
            Assert.False(pilha.EstaVazia());
            Assert.Equal(2, pilha.Tamanho());
        }

        [Fact]
        public void EmpilhaDoisEDesempilhaUmElemento()
        {
            pilha.Empilha("primeiro");
            Assert.Equal("primeiro", pilha.Topo());

            pilha.Empilha("segundo");
            Assert.Equal("segundo", pilha.Topo());
            Assert.False(pilha.EstaVazia());
            Assert.Equal(2, pilha.Tamanho());

            Assert.Equal("segundo", pilha.Desempilha());
            Assert.Equal(1, pilha.Tamanho());
            Assert.Equal("primeiro", pilha.Topo());
            Assert.False(pilha.EstaVazia());            
        }

        [Fact]      
        public void RetiraDePilhaVazia()
        {
            Assert.ThrowsAny<InvalidOperationException>(() => pilha.Desempilha());
        }

        [Fact]
        public void AdicionaNaPilhaCheia()
        {
            for (int i = 0; i < 10; i++)
            {
                pilha.Empilha($"objeto {i}");
            }
            Assert.ThrowsAny<InvalidOperationException>(() => pilha.Empilha("Booom"));
        }
    }
}
