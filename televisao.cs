
public class Televisao
{
private const int TOTAL_CANAIS_SUPORTADOS = 520;
private const int VOLUME_MINIMO = 0;
private const int VOLUME_MAXIMO = 100;

public float Tamanho { get; set; }
public int Resolucao { get; set; }
public int Volume { get; set; }
public int Canal { get; set; }
public bool Estado { get; set; } 

private int ultimoCanal = 1;
private int? volumeAntesDoMudo = null;

public Televisao(float tamanho)
{
Tamanho = tamanho;
Resolucao = 1080;
Volume = 10;
Canal = 1;
Estado = false;
}

public void Ligar()
{
Estado = true;
Canal = ultimoCanal; // Ao ligar, retoma o último canal assistido
}

public void Desligar()
{
Estado = false;
ultimoCanal = Canal; // Sempre salva o último canal ao desligar
volumeAntesDoMudo = null; // limpa marcador de mudo
}

public void ProximoCanal()
{
if (!Estado) return;
if (Canal < TOTAL_CANAIS_SUPORTADOS)
Canal++;
}

public void CanalAnterior()
{
if (!Estado) return;
if (Canal > 1)
Canal--;
}

public bool IrParaCanal(int numeroDoCanal)
{
if (!Estado) return false;
if (numeroDoCanal < 1 || numeroDoCanal > TOTAL_CANAIS_SUPORTADOS)
return false;

Canal = numeroDoCanal;
ultimoCanal = Canal;
return true;
}

public void AumentarVolume()
{
if (!Estado) return;

if (EstaEmMudo()) DesativarMudo();
if (Volume < VOLUME_MAXIMO)
Volume++;
}

public void DiminuirVolume()
{
if (!Estado) return;

if (EstaEmMudo()) DesativarMudo();
if (Volume > VOLUME_MINIMO)
Volume--;
}

public void AtivarMudo()
{
if (!Estado) return;

if (!EstaEmMudo())
{
volumeAntesDoMudo = Volume;
Volume = 0;
}
}

public void DesativarMudo()
{
if (!Estado) return;

if (EstaEmMudo())
{
Volume = volumeAntesDoMudo ?? 10; // restaura um volume válido
volumeAntesDoMudo = null;
}
}

public void AlternarMudo()
{
if (EstaEmMudo()) DesativarMudo();
else AtivarMudo();
}

public bool EstaEmMudo()
{
return volumeAntesDoMudo.HasValue;
}
}
