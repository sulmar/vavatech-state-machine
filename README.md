# Maszyna stanów w praktyce
Kod źródłowy pochodzący z mojego webinarium.

## Wprowadzenie
**Maszyna stanów** może wydawać abstrakcyjną, matematyczną koncepcją, o której zwykle zapominamy wraz z zaliczonym egzaminem na studiach. 
Jednak w rękach sprytnego programisty może być bardzo efektywnym wzorcem do zarządzania stanem obiektu, np. zamówienie, faktura, wniosek urlopowy, sterowanie sprzętem.

## Wymagania
- .NET Core 3.1 lub wyższy

## Abstrakt
Maszyna stanów to zbiór stanów _states_ (s1, s2 ... sN) oraz przejść _triggers_ (t1, t2 ... tN). 
Obiekt może znajdować się w jednym momencie tylko w jednym ze stanów.
Na początku maszyna stanów przyjmuje stan początkowy. Przejścia pomiędzy stanami następują za pomocą triggerów.

![State machine abstract](drafts/state-machine-abstract.png)


## Wizualizacja grafu
- http://www.webgraphviz.com
- https://dreampuf.github.io/GraphvizOnlin

## Biblioteki w innych językach
- **Arduino** Automaton
https://www.arduinolibraries.info/libraries/automaton

- **Go** Stateless https://github.com/qmuntal/stateless

