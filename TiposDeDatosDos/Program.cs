using System.Drawing;
using TiposDeDatosDos; //lugar donde se encuentra el enum para poder usarlo en este archivo.

// TosTring(): función que permite cambiar cualquier tipo de dato a string.
int cantidadUno = 5;

//C# nos obliga a hacer la comparación entre tipos de datos iguales, si no, marca error; por éso
//se convierte "cantidadUno" a string.
if (cantidadUno.ToString() == "5")
{
    Console.WriteLine("Son iguales.");
}

string hoy = DateTime.Today.ToString("dd-MM-yyyy (dddd)"); //ésto sólo funciona para datetime para convertir a string.
Console.WriteLine(hoy);

//También se puede convertir de string a otros tipos de dato.
//Parse(): permite convertir de string a entero, a decimal, a bool, a DateTime.
string cantidadString = "5";
int cantidad = int.Parse(cantidadString);
cantidad++; //comprobar que sí se convirtió a entero xq un string no se puede sumar, pues regresa error.
Console.WriteLine(cantidad);

string decimalString = "4.5";
decimal cantidadDecimal = decimal.Parse(decimalString);
cantidadDecimal++;
Console.WriteLine(cantidadDecimal);

string boleanoString = "true";
bool boleano = bool.Parse(boleanoString);

if (boleano)
{
    Console.WriteLine($"Se convirtió de string a booleano. {boleano}");
}

string fechaString = "2022-05-09";
DateTime fecha = DateTime.Parse(fechaString);
Console.WriteLine(fecha.AddYears(1)); //Comprobar que sí se convirtió en fecha.



//TryParse(): función que convierte a cierto tipo de dato sólo si tiene el formato correcto, de lo contrario, regresa falso.
//Corregir errores al intentar convertir un tipo de dato a otro que no es reconocido.
string supuestoNumero = "no es un número";

//la siguiente línea causa error porque la variable "supuestoNumero" no contiene un número para convertir a entero.
//Error: int noEsNumero = int.Parse(supuestoNumero);
int numero;
bool intentoParseo = int.TryParse(supuestoNumero, out numero);

if (intentoParseo)
{
    numero++;
    Console.WriteLine(numero);
} else
{
    Console.WriteLine($"El valor ´{supuestoNumero}´ no tiene el formato correcto para convertir a entero.");
}


//Casteos de tipos de datos numéricos
int primeroNumero = 4;
int segundoNumero = 5;

//se convierte un entero a double (mínimo) para que se pueda realizar la división y muestre un
//resultdo más acertado porque si no, regresa un resultado erróneo en entero.
double division = (double)primeroNumero/ segundoNumero;
Console.WriteLine($"La división es: {division}");


//Casteo de entero a byte (hay que tener cuidado porque puede haber un overflow).
//Un entero NO siempre va a caber en un byte.
byte byteUno;
int enteroUno = 10;

//Lanza una excepción en caso de un desbordamiento de la memoria.
checked
{
    byteUno = (byte)enteroUno;
}

Console.WriteLine(byteUno);

//Casteo implícito de byte a entero: es difícil que exista un desbordamiento de la memoria
// en este caso porque un tipo de dato byte siempre va a caber en un entero (aun así no hay que descartarlo).

byte byteDos = 11;
int intDos;

intDos = byteDos;

Console.WriteLine(intDos);



//Enum: valor especial que permite agrupar un conjunto de constantes numéricas.
//los valores de los enums son simples números.
//Los enums empiezan a contar a partir del 0; C# le pone un número a cada variable por defecto:
    //0. Exitoso
    //1. PendienteDePago
    //2. Cancelada
//Se puede elegir el número por el cual el enum puede empezar a contar.
EstadoVentas estadoVentaRopa = EstadoVentas.Exitoso;

switch (estadoVentaRopa)
{
    case EstadoVentas.Exitoso:
        Console.WriteLine("La venta fue exitosa.");
        break;
    case EstadoVentas.PendienteDePago:
        Console.WriteLine("El cliente debe pagar.");
        break;
    case EstadoVentas.Cancelada:
        Console.WriteLine("Venta cancelada.");
        break;
    default:
        Console.WriteLine("Estado desconocido.");
        break;
}

//Castear el enum a entero:
int status = (int)estadoVentaRopa;
Console.WriteLine(status);

//Castear de entero al valor del enum:
int otroEstado = 3;
EstadoVentas estadoNombre = (EstadoVentas)otroEstado;
Console.WriteLine(estadoNombre);


//Estructuras de datos
// 1. Arreglos: representación de un número fijo de elementos de un tipo de dato en particular.
//Un arreglo es una colección de elementos del mismo tipo.
//Los arreglos son un tipo de dato estructurado de referencia no nula.


//Arreglo de caracteres.
char[] vocales = new char[5];
vocales[0] = 'a'; //Elemento inicial -> los arreglos comienzan a contarse desde 0.
vocales[1] = 'e';
vocales[2] = 'i';
vocales[3] = 'o';
vocales[4] = 'u';

Console.WriteLine(vocales[2]);
//Console.WriteLine(vocales[5]); //Regresa una excepción de error porque el 5 está fuera del rango del número de elementos del arreglo.

//se puede usar forEach para ingresar a los elementos del arreglo sin tener que ir uno por uno.
foreach (char vocal in vocales)
{
    Console.WriteLine(vocal);
}

//Forma 2
int[] primerosCinco = new int[] {1, 2, 3, 4, 5};
foreach (int numeroIndividual in primerosCinco)
{
    Console.Write(numeroIndividual);
}

//Obtener el número más grande
int[] numeroMasGrande = new int[] { 10, 5, 43, 20 };
int numeroMayor = numeroMasGrande[0];

foreach (int numeroArreglo in numeroMasGrande)
{
    if (numeroMayor < numeroArreglo)
    {
        Console.WriteLine($"\n\n{numeroMayor}");
        numeroMayor = numeroArreglo;
    }
}

Console.WriteLine($"\nEl número más grande es: { numeroMayor}");


//Índices
char[] letras = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
//Acceder manualmente a los índices
Console.WriteLine(letras[0]); // a
Console.WriteLine(letras[1]); // b
Console.WriteLine(letras[^1]); // último elemento del arreglo -> f
Console.WriteLine(letras[^2]); // penúltimo elemento del arreglo -> e
// también se puede hacer lo siguiente
Index antepenultimoElemento = ^3;
Console.WriteLine(letras[antepenultimoElemento]); // -> d


//Rangos: extraer varios elementos de un arreglo
char[] dosPrimerasLetras = letras[..2]; //significa que se está contando hasta el elemento 2 SIN incluirlo -> c
int contador = 0;

foreach (char letra in dosPrimerasLetras)
{
    contador++;
    Console.WriteLine($"La letra {contador} es: {letra}"); //se imprime la "a" y la "b".
}

Range tresPrimerasLetras = ..3;
int contadorCero = 0;

foreach (char letraTres in letras[tresPrimerasLetras])
{
    contadorCero++;
    Console.WriteLine($"\n\nLa letra {contadorCero} es: {letraTres}"); //se imprime la "a" y la "b".
}

char[] dosUltimasVocales = letras[^2..];
int otroContador = 4;

foreach (char UltimasDos in dosUltimasVocales)
{
    otroContador++;
    Console.WriteLine($"\n{otroContador} es: {UltimasDos}"); //se imprime la "a" y la "b".
}


char[] tresUltima = letras[3..];
int count = 3;

foreach (char tresAdelante in tresUltima)
{
    count++;
    Console.WriteLine($"\n{count} es: {tresAdelante}"); //se imprime la "a" y la "b".
}

char[] obtenerElementosMedio = letras[1..5]; //ignora el primero y el último
char[] obtenerElementosMedio2 = letras[1..^1]; //ignora el primero y el último


//Arreglos multidimensionales: la coma hace al arreglo bidimensional (matriz)
int[,] matriz = new int[2, 2];
Console.WriteLine(matriz.Rank); //2 dimensiones

matriz[0, 0] = 1; //primera fila, primera columna
matriz[0, 1] = 2; //primera fila, segunda columna
matriz[1, 0] = 3; //segunda fila, primera columna
matriz[1, 1] = 4; //segunda fila, segunda columna

var elemento01 = matriz[0, 1]; // regresa 2
Console.WriteLine(elemento01);

int[,] matrizDos = new int[,] //matriz de 3x2 (3 filas, 2 columnas
{
    {5, 6}, //primera fila
    {5, 7}, //segunda fila
    {5, 8}, //tercera fila
};

// GetLenght(): cantidad o número de elementos que cada dimensión puede contener
for (int fila = 0; fila < matriz.GetLength(0); fila++)
{
    for (int columna = 0; columna < matriz.GetLength(1); columna++)
    {
        Console.Write($"{matriz[fila, columna]} ");
    }
    Console.WriteLine();
}

for (int fila = 0; fila < matrizDos.GetLength(0); fila++)
{
    for (int columna = 0; columna < matrizDos.GetLength(1); columna++)
    {
        Console.Write($" {matrizDos[fila, columna]} ");
    }
    Console.WriteLine();
}


//Arreglos de arreglos: arreglos cuyos elementos son otros arreglos.
int[][] arrayOfArray =
{
    //este arreglo de arreglos se compone de 4 arreglos y por tanto, cada uno de sus elementos es un arreglo.
    new int[] {5, 6},
    new int[] {7, 8, 11},
    new int[] {9, 10},
    new int[] {12}
};

int[] segundoElemento = arrayOfArray[1];
Console.Write($"\n");
foreach (int valor in segundoElemento)
{
    Console.Write($"{valor} ");
}
