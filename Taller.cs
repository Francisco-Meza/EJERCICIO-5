using System;
using System.Collections.Generic;

class Taller
{
    //-------------------------- ATRIBUTOS --------------------------------
    private string[,] carros;
    private List<string> carrosAcumulados;
    private List<int> monto;
    private int indice;
    private int indiceS;
    //-------------------------- CONSTRUCTOR -----------------------------
    public Taller(int n)
    {
        N = n;//-- NUMERO DE CAPACIDAD MAXIMA DE AUTOS DENTRO DEL TALLER
        Carros = new string[N,2];
        Monto = new List<int>();
        CarrosAcumulados = new List<string>();
        IndiceS = 0;
        Indice = 0;//-- AYUDARA A CONTAR PARA VER LA DISPONIBILIDAD DE ESPACIOS
        for(int rows = 0; rows < N; rows++)//-- PONE TODO LOS ESPACIOS SIN INFO PARA VER QUE ESTA DISPONIBLE
        {
            for(int columns = 0; columns < 2; columns++)
            {
                Carros[rows, columns] = " - ";
            }
        }
    }
    //------------------------- METODOS ---------------------------
    public Boolean Meter(string placas, string nombreDueño)
    {

        if (Indice < N)//-- METE UN AUTO AL TALLER
        {
            for (int i = 0; i < N; i++)
            {
                if (Carros[i, 0] == " - ")
                {
                    Indice = i;
                    break;
                }
            }
            Carros[Indice, 0] = placas;
            Carros[Indice, 1] = nombreDueño;
            string value = $"{placas}, {nombreDueño}";
            CarrosAcumulados.Add(value);
            return true;
        }
        return false;
    }
    public Boolean Sacar()//-- SACA UN AUTO DEL TALLER
    {
        if(Indice-1 >= 0)//--
        {
            for (int i = 0; i < N; i++)
            {
                if (Carros[i, 0] != " - ")
                {
                    Carros[i, 0] = Carros[i + 1, 0];
                    Carros[i, 1] = Carros[i + 1, 1];
                }
            }
            Carros[N-1, 0] = " - ";
            Carros[N-1, 1] = " - ";
            return true;
        }
        return false;
    }
    public string EspacioDisponible()//-- DEVUELVE EL ARREGLO DE CARROS QUE ESTAN ADENTRO
    {
        String ans = "";
        for (int rows = 0; rows < N; rows++)//-- MUESTRA ESPACIOS DISPONIBLES
        {
            ans += carros[rows, 0] + ", ";
            ans += carros[rows, 1] + "\n";
        }
        return ans;
    }
    public void Cobrar(int monto)//-- COBRA EL DINERO Y LO GUARDA EN UNA LISTA
    {
        Monto.Add(monto);
    }
    public int[] GetMonto()//-- DEVUELVE LA LISTA DEL MONTO EN FORMA DE ARREGLO
    {
        int[] AMonto = Monto.ToArray();
        return AMonto;
    }
    public string[] GetCarrosAcumulados()//-- DEVUELVE LA LISTA DE CARROS ACUMULADOS EN UN ARREGLO
    {
        string[] ACarrosAcumulados = CarrosAcumulados.ToArray();
        return ACarrosAcumulados;
    }
    //------------------------- PROPIEDADES ----------------------
    public string[,] Carros { get => carros; set => carros = value; }
    public int N { get; }
    public List<int> Monto { get => monto; set => monto = value; }
    public int Indice { get => indice; set => indice = value; }
    public List<string> CarrosAcumulados { get => carrosAcumulados; set => carrosAcumulados = value; }
    public int IndiceS { get => indiceS; set => indiceS = value; }
}
