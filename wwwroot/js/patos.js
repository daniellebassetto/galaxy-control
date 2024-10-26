const patosContainer = document.getElementById('patos-container');
const infoList = document.getElementById('info-list');
const loadingBar = document.getElementById('loading-bar');

const positions = new Set(); // Conjunto para armazenar posições ocupadas

function mostrarLoading() {
    loadingBar.style.display = 'block'; // Exibir a barra de carregamento
    setTimeout(() => {
        loadingBar.style.display = 'none'; // Ocultar após 2 segundos
        iniciarMonitoramento();
    }, 2000); // 2000 ms = 2 segundos
}

function iniciarMonitoramento() {
    // Gerar patos a cada 3 segundos
    setInterval(criarPato, 3000); // 3000 ms = 3 segundos
}

function criarPato() {
    const patoDiv = document.createElement('div');
    patoDiv.classList.add('pato');

    // Definindo características aleatórias do pato
    const distancia = (Math.random() * 100).toFixed(2); // Distância aleatória
    const isXenofago = Math.random() < 0.5; // 50% de chance de ser um Xenófago
    const emBando = Math.random() < 0.5; // 50% de chance de estar em bando
    const atividadesSuspeitas = emBando ? "Comunicação estranha" : "Nenhuma atividade suspeita"; // Ação baseada no bando

    // Gerar uma posição única
    let position;
    do {
        position = {
            left: Math.random() * 90 + 'vw', // posição horizontal aleatória
            top: Math.random() * 80 + 'vh' // posição vertical aleatória
        };
    } while (positions.has(`${position.left}-${position.top}`)); // Verificar se a posição já está ocupada

    positions.add(`${position.left}-${position.top}`); // Adiciona a posição ao conjunto

    // Configurando o texto do pato
    patoDiv.style.left = position.left;
    patoDiv.style.top = position.top;
    patoDiv.innerHTML = `<img src="~/img/${isXenofago ? 'pato_xenofago' : 'pato_normal'}.jpg" alt="Pato" />`;

    patosContainer.appendChild(patoDiv);

    // Adiciona as informações à lista
    const infoItem = document.createElement('li');
    infoItem.innerText = `Pato a ${distancia} km - ${isXenofago ? "Xenófago" : "Pato Normal"} - ${emBando ? "Em Bando" : "Solitário"}`;
    infoList.appendChild(infoItem);
}

// Inicia o monitoramento assim que a página carregar
$(document).ready(function () {
    mostrarLoading();
});
