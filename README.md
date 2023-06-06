
# Tragic, The Reckoning

## Autoria

- João Neto, 22200558
- Ricardo Almeida, 21807601


## Divisão

- João Neto:
 	- Estrutura do Projeto
	- Diagrama UML
	- BuyingPhase
	- BuyingView
	- SpellPhase
	- SpellView

- Ricardo Almeida:
	- README
	- BattlePhase
	- BattleView
	- EndPhase
	- EndView


## Repositório Git

Repositório Git disponível [aqui](https://github.com/JNetoGH/LP1-Project-2).


## Arquitetura de Solução

O nosso programa começa por criar uma instância de GameLoop e em seguida pede
aos jogadores por nomes customizados de cada jogador que usa para criar dois
objetos de Player.

Em seguida, inicializa o método Run do GameLoop que initializa o jogo como os
players a valores default e uma variável counter a 1 (esta variável informa o
número do turno atual). Após isto, começa o loop que interrompe imediatamente
quando for detetada uma Exception (que iremos utilizar para quebrar intencionalmente).

O loop começa pelo RunPhase (método contido por todas as phases visto vir da
Interface IPhase) da BuyingPhase.


## Diagrama UML


## Referências

- [.NET Standard 2.0](https://learn.microsoft.com/en-us/dotnet/api/?view=netstandard-2.0&term=List)