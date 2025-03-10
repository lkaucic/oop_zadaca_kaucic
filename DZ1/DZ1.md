# Zadaća 1 - Osnove OOP

## Zadatak

Radite sustav koji omogućuje rad s epizodama TV serije s brojem gledatelja, ukupnom sumom njihovih ocjena i najvećom danom ocjenom iz intervala [0.0-10.0]. Implementirajte sve potrebne klase definirajući njihova stanja i metode kako bi se testni program u nastavku mogao ispravno izvesti.

## Pravila

* Koristiti programski jezik je C#
* Svaka klasa ide u zaseban file
* Kreirati dva projekta unutar solutiona, jedan koji će biti definiran kao *class library* i u kojem će biti logika rješenja, a drugi koji će biti konzolna aplikacija i koji će predstavljati UI
* Koristiti .NET Core projekte u VS-u
* Uploadati rješenje na GitHub, na privatni repozitorij
* Zalijepiti link na repozitorij za predaju zadaće
* Prepisivanje je strogo zabranjeno i bit će kažnjavano

## Testni program

```c#	
	Episode ep1, ep2;	
	ep1 = new Episode();
	ep2 = new Episode(10, 64.39, 8.7);
	int viewers = 10;
	for (int i = 0; i < viewers; i++) {
		ep1.AddView(GenerateRandomScore());
		Console.WriteLine (ep1.GetMaxScore());
	}
	if (ep1.GetAverageScore() > ep2.GetAverageScore()) {
		Console.WriteLine($"Viewers: {ep1.GetViewerCount()}";
	}
	else {
		Console.WriteLine($"Viewers: {ep2.GetViewerCount()}";
	}
```

## Primjer izlaza

1.	0.0125126
2.	5.63585
3.	5.63585
4.	8.08741
5.	8.08741
6.	8.08741
7.	8.08741
8.	8.95962
9.	8.95962
10.	8.95962
11.	Viewers: 10
