using System;
using System.Collections.Generic;

public static class ContaCorrenteValidations
{
    public static bool HasSaldo(decimal saldoAtual, decimal valorLancamento)
    {
        if (valorLancamento <= saldoAtual)
            return true;
        return false;
    }

    public static bool HasSaldoByCreditoDebito(decimal creditos, decimal debitos)
    {
        var saldo = creditos - debitos;

        if (saldo <= 0)
            return false;
        return true;
    }
}