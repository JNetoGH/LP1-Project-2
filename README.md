
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

O nosso programa começa por criar uma instância de GameLoop e correr o método Run
do GameLoop que initializa o jogo com os players a valores default e uma variável
counter a 1 (esta variável informa o número do turno atual). Após isto, começa
o loop que interrompe imediatamente quando for detetada uma Exception (que
iremos utilizar para quebrar intencionalmente).

O loop começa pelo RunPhase (método contido por todas as phases visto vir da
Interface IPhase) da BuyingPhase.

A BuyingPhase incorpora a BuyingView para informar o jogador do que acontece
ao longo desta e deixa o jogador comprar cartas se tiver menos de 6 na mão. Se
o jogador ao comprar um carta ficar com 0 cartas no Deck, ocorre uma Exception
termina o loop inicial e avança diretamente para a EndPhase. Se isto não acontecer,
o loop continua para a SpellPhase.

A SpellPhase incorpora a SpellView para informar o jogador do que acontece ao
longo desta e permite ao jogador jogar cartas da sua mão para o battlefield
desde que tenha mana para tal fazer. De seguida, o loop continua para a BattlePhase.

A BattlePhase incorpora a BattleView para informar o jogador do que acontece ao
longo desta e calcula as regras de combate entre as cartas jogadas de acordo com
as regras estipuladas no enunciado.

As regras causavam um problema caso as cartas de topo não conseguissem matarem-se
umas às outras pelo que optamos por resolver isto ao tornar o dano dado a cada
carta permamente, ou seja, uma carta 1/0 consegue matar uma carta 0/4 se a atacar
em 4 turnos.

De seguida, o loop retornaria à BuyingPhase, no entanto, se algum jogador
morrer, o loop é interrompido e passa para a EndPhase.

A EndPhase utiliza a EndView para informar o jogador de quem ganhou ou se ocorreu
um empate.

## Diagrama UML
![image](https://github.com/JNetoGH/LP1-Project-2/assets/24737993/ae6af116-8e77-4d84-a2a6-e0f4cec4436a)


## Referências

- [.NET Standard 2.0](https://learn.microsoft.com/en-us/dotnet/api/?view=netstandard-2.0&term=List)
