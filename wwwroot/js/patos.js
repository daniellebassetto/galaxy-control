const patosContainer = document.getElementById('patos-container');
const loadingBar = document.getElementById('loading-bar');
const loadingMessage = document.getElementById('loading-message');
const positions = new Set();

function mostrarLoading() {
    loadingBar.style.display = 'block';
    setTimeout(() => {
        loadingBar.style.display = 'none';
        loadingMessage.textContent = 'Óculos conectado';
        iniciarMonitoramento();
    }, 3000);
}

function iniciarMonitoramento() {
    criarPatoComIntervaloAleatorio();
}

function criarPatoComIntervaloAleatorio() {
    const intervaloAleatorio = Math.random() * (10000 - 5000) + 5000;
    setTimeout(() => {
        criarPato();
        criarPatoComIntervaloAleatorio(); 
    }, intervaloAleatorio);
}

function criarPato() {
    const patoDiv = document.createElement('div');
    patoDiv.classList.add('pato-container');

    const distancia = (Math.random() * 100).toFixed(2); 
    const isXenofago = Math.random() < 0.5;
    const emBando = Math.random() < 0.5;

    const containerWidth = patosContainer.clientWidth;
    const containerHeight = patosContainer.clientHeight;

    let position;
    do {
        position = {
            left: Math.random() * (containerWidth - 150) + 'px', 
            top: Math.random() * (containerHeight - 150) + 'px'  
        };
    } while (positions.has(`${position.left}-${position.top}`));

    positions.add(`${position.left}-${position.top}`);

    patoDiv.style.left = position.left;
    patoDiv.style.top = position.top;

    const imgSrc = emBando
        ? isXenofago ? '/img/bando_pato_xenofago.png' : '/img/bando_pato_normal.png'
        : isXenofago ? '/img/pato_xenofago.png' : '/img/pato_normal.png';

    patoDiv.innerHTML = `
        <img src="${imgSrc}" alt="Pato" class="pato">
        <p class="pato-info">Distância: ${distancia} km</p>
    `;

    patosContainer.appendChild(patoDiv);

    const tempoRemocaoAleatorio = Math.random() * (20000 - 10000) + 10000;
    setTimeout(() => {
        patoDiv.remove();
        positions.delete(`${position.left}-${position.top}`); 
    }, tempoRemocaoAleatorio);
}

document.addEventListener('DOMContentLoaded', function () {
    mostrarLoading();
});