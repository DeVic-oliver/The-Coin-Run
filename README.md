# The-Coin-Run
Game for Bugaboo job application


# INSTRUÇÕES:
Tempo da partida single player e multiplayer:
- Acessem o objeto MANAGERS > GAME.
- Alterem o tempo no componente GAME TIMER;
- Movimentação WS e rotação AD;

# DEPENDÊNCIAS e CONFIGURAÇÕES
- Versão da Unity 2022.3.4f1.
- Testado em Windows.
- Instalar o Game em desktops distintos.
- O game está rodando com o IP da minha aplicação na plataforma do PHOTON, ficará online até o fim do processo.

# BUILD
O projeto já está configurado para ser compilado, basta apenas seguir o procedimento de build padrão da Unity.
- File
- Build Settings
- Build

# CONSIDERAÇÕES:
Agradeço pela oportunidade, foi um excelente desafio que me permitiu explorar e conhecer o desenvolvimento multiplayer.
Abaixo algumas descrições das soluções.

- Design Patterns (Overserve, State e Pooling);
- Save (JSON e PlayerPrefs);
- Photon para o network;
- Assemblies para dividir os domínios;
- UTF para testar algumas classes estáticas;

Decidi dividir o projeto em Single Player e Multiplayer, alguns tópicos dos requisitos funcionam melhor em ambientes diferentes.

# SISTEMA DE SAVE:
O "best score" do jogador é salvo no single player em JSON na máquina do jogador através da JSONUTILITY.
O nickname do jogador é salvo em PlayerPrefs para o jogo multiplayer.

# A GAMEPLAY:
A gameplay é gerenciada por uma série de eventos que usam a UnityEvent. 
A cena single player tende a fazer mais usos deste sistema.

# AS MOEDAS:
As moedas são criadas aleatóriamente através de um sistema de coordênadas que desenvolvi e utilizando o design pattern "Pooling". 
Desta forma o spawn é mais controlado e impede que surjam infinitas moedas.

# MOVIMENTAÇÃO DO JOGADOR:
O jogador é movimentado pelo sistema de física do Rigidbody para ter uma melhor detecção de colisão com o mundo.
A movimentação é feita através do Design Pattern "State". Costumo desenvolver State Machines para lidar com comportamentos, 
fica mais fácil de gerenciar e o controle fica mais consistente.

# MULTIPLAYER
O multiplayer foi implementado e sincronizado com o Photon.
A pool de moedas, as moedas e contagem de pontos são sincronizados com o Host.

