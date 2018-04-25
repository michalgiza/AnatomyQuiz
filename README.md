## Załózenia projektowe

ZAWSZE USTALAMY PRACE NAD SCENAMI- JEDNA OSOBA PRACUJE NAD JEDNĄ SCENĄ.
Musimy się tego trzymać, ponieważ później przy mergu program nie umie tego pogodzić i trzeba wybrać czy zachować scene swoja czy kogoś (nie da się połączyć dwóch scen).

NIGDY nie commitujemy bezpośrednio do mastera

Przed zmergowaniem się z masterem sprawdzamy czy wszystko działa i śmiga.

Schemat megowania:
1. Pushujemy wszystkie zmiany na SWOJEGO bruncha
2. Wchodzimy na mastera
3. Zaciagamy lokalnie mastera do siebie, oraz merguemy z naszym brunchem LOKALNIE, dopieor po sprawdzeniu że merg nie wysypał apki pushujemy zmiany na serwer.

Również ważne:
1. Dla każdego taska robimy NOWEGO bruncha
2. Nad każdą metodą wpisujemy "//" dla łatego zlokalizowania
3. Nazwy metod muszą być informatywne
4. Trello! SCRUM!
5. Jeśli robimy jakiegoś taska, sprawdzamy czy ktos aktualnie nie pracuje na danej scenie bo wtedy sie posypie nasza lub czyjaś robota (nie dotyczy pracy nad skryptami).
6. Po skończeniu taska, odznaczamy na trello na "zrobione", jeśli ktoś czeka na prace nad sceną musimy zmergować się z masterem a osoba, która czeka zaciaga te zmiany.
