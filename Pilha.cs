using System;
using System.Collections.Generic;
using System.Text;

namespace XPilha
{
    class Pilha
    {
        private Object[] elementos;
        private int quantidade = 0;

        public Pilha(int maximo)
        {
            elementos = new object[maximo];
        }

        public bool EstaVazia() => (quantidade == 0);
        

        public int Tamanho() => quantidade;
        

        public void Empilha(Object obj)
        {
            if (quantidade == elementos.Length)
                throw new InvalidOperationException("A pilha está cheia");
            elementos[quantidade] = obj;
            quantidade++;
        }

        public Object Desempilha()
        {
            if (this.EstaVazia())
                throw new InvalidOperationException("A pilha está vazia");
            object ret = Topo();            
            quantidade--;
            return ret;
        }

        public Object Topo() => elementos[quantidade-1];
    }
}
