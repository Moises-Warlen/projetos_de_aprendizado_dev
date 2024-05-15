document.addEventListener('DOMContentLoaded', () => {
    const gameArea = document.getElementById('gameArea');
    const fruit = document.getElementById('fruit');
    const scoreDisplay = document.getElementById('score');
    const startButton = document.getElementById('startButton');

    let score = 0;
    let snakeX = 10;
    let snakeY = 10;
    let fruitX = 0;
    let fruitY = 0;
    let interval;
    let speed = 300; // Velocidade inicial da cobrinha (quanto maior o valor, mais devagar)
    let tail = [];
    let tailLength = 1; // Comprimento inicial da cobrinha
    let direction = 'right';

    function startGame() {
        score = 0;
        snakeX = 10;
        snakeY = 10;
        fruitX = Math.floor(Math.random() * 19);
        fruitY = Math.floor(Math.random() * 19);
        tail = [];
        tailLength = 1;
        direction = 'right';
        updateScore();
        drawSnake();
        drawFruit();
        clearInterval(interval);
        interval = setInterval(moveSnake, speed);
    }

    function drawSnake() {
        // Remover segmentos antigos da cobrinha
        const snakeSegments = document.querySelectorAll('.snakeSegment');
        snakeSegments.forEach(segment => segment.remove());

        // Desenhar o corpo da cobrinha
        for (let i = 0; i < tail.length; i++) {
            const segment = document.createElement('div');
            segment.classList.add('snakeSegment');
            segment.style.left = tail[i].x * 20 + 'px';
            segment.style.top = tail[i].y * 20 + 'px';
            gameArea.appendChild(segment);
        }
    }

    function drawFruit() {
        fruit.style.left = fruitX * 20 + 'px';
        fruit.style.top = fruitY * 20 + 'px';
    }

    function moveSnake() {
        switch(direction) {
            case 'up':
                snakeY--;
                break;
            case 'down':
                snakeY++;
                break;
            case 'left':
                snakeX--;
                break;
            case 'right':
                snakeX++;
                break;
        }

        if (snakeX < 0 || snakeX >= 20 || snakeY < 0 || snakeY >= 20) {
            gameOver();
            return;
        }

        for (let i = 0; i < tail.length; i++) {
            if (snakeX === tail[i].x && snakeY === tail[i].y) {
                gameOver();
                return;
            }
        }

        if (snakeX === fruitX && snakeY === fruitY) {
            score += 10;
            speed -= 10; // Aumenta a velocidade da cobrinha
            tailLength++; // Aumenta o comprimento da cobrinha
            updateScore();
            fruitX = Math.floor(Math.random() * 20);
            fruitY = Math.floor(Math.random() * 20);
            drawFruit();
        }

        // Adiciona um segmento ao corpo da cobrinha
        tail.unshift({ x: snakeX, y: snakeY });

        // Remove segmentos extras do corpo da cobrinha
        while (tail.length > tailLength) {
            tail.pop();
        }

        drawSnake();
    }

    function updateScore() {
        scoreDisplay.innerText = 'Pontuação: ' + score;
    }

    function gameOver() {
        clearInterval(interval);
        alert('Fim de Jogo! Pontuação: ' + score);
    }

    document.addEventListener('keydown', (e) => {
        switch(e.key) {
            case 'ArrowUp':
                if (direction !== 'down')
                    direction = 'up';
                break;
            case 'ArrowDown':
                if (direction !== 'up')
                    direction = 'down';
                break;
            case 'ArrowLeft':
                if (direction !== 'right')
                    direction = 'left';
                break;
            case 'ArrowRight':
                if (direction !== 'left')
                    direction = 'right';
                break;
        }
    });

    startButton.addEventListener('click', startGame);
});