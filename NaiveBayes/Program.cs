using System;
using System.Collections.Generic;
using System.IO;

namespace NaiveBayes
{
    class Program
    {
        // TODO: Wörterbuch aus den Texten aufbauen
        // TODO: Absolute Häufigkeiten der Klassen: atheism, graphics, windows, ibm, mac, pc, forsale, autos, motorcycles, baseball, hockey, crypt, electronics, med, space, christian, guns, mideast, politics, religion
        // TODO: Absolute Häufigkeiten jedes Wortes des Wörterbuchs für jede Klasse speichern
        // TODO: Unbekannten Text einlesen
        // TODO: Text anhand des Wörterbuchs in einen Vektor umwandeln
        // TODO: Vektor mit der Naive-Bayes Formel in eine der 20 Klassen einteilen
        // TODO: Einteilung überprüfen und gegebenenfalls korrigieren


        // TODO: Unbekannte Wörter ins Wörterbuch aufnehmen
        // TODO: Absolute Häufigkeit der eingeteilten Klasse aktualisieren
        // TODO: Absolute Häufigkeiten der unbekannten Worter für jede Klasse hinzufügen

        static void Main(string[] args)
        {
            Controll controll = new Controll();
            controll.Setup();
        }
    }
}