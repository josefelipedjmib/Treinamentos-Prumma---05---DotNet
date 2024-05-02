public static class Numero{
    public static int TextoParaInteiro(string numero, int padrao = 0)
    {
        var retorno = 0;
        var converteu = int.TryParse(numero, out retorno);
        if(!converteu)
            retorno = padrao;
        return retorno;
    }
}