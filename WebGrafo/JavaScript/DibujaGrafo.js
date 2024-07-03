

function mostrarGrafo(verticesJson) {
    var canvas = document.getElementById("miCanvas");
    var ctx = canvas.getContext('2d');

    const vertices = verticesJson.map(v => ({
        id: v.IdUsuario,
        name: v.Nombres,
        edges: v.aristas.map(a => ({
            to: a.IdUsuario,
            name: a.Nombres,
            cost: a.cost
        }))
    }));

    // Función para graficar el grafo
    function drawGraph(vertices) {
        // Calcula las coordenadas de los vértices distribuidos en un círculo
        const radius = Math.min(canvas.width, canvas.height) * 0.4;
        const centerX = canvas.width / 2;
        const centerY = canvas.height / 2;
        vertices.forEach((vertex, index) => {
            const angle = (index / vertices.length) * 2 * Math.PI;
            vertex.x = centerX + radius * Math.cos(angle);
            vertex.y = centerY + radius * Math.sin(angle);
        });

        // Limpia el canvas
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        // Dibuja las aristas
        drawEdges(vertices);

        // Dibuja los vértices
        drawVertices(vertices);
    }

    // Dibuja los vértices
    function drawVertices(vertices) {
        ctx.fillStyle = 'blue';
        vertices.forEach(vertex => {
            ctx.beginPath();
            ctx.arc(vertex.x, vertex.y, 45, 0, 2 * Math.PI);
            ctx.fill();
            ctx.stroke();

            ctx.font = '15px Arial';
            ctx.fillStyle = 'white';
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillText(vertex.id + "-" + vertex.name, vertex.x, vertex.y);
            ctx.fillStyle = 'blue';
        });
    }

    // Dibuja las aristas 
    function drawEdges(vertices) {
        ctx.strokeStyle = 'black';
        ctx.lineWidth = 2;
        vertices.forEach(vertex => {
            vertex.edges.forEach(edge => {
                const toVertex = vertices.find(v => v.id === edge.to);
                if (toVertex) {
                    // Dibuja la línea principal
                    ctx.beginPath();
                    ctx.moveTo(vertex.x, vertex.y);
                    ctx.lineTo(toVertex.x, toVertex.y);
                    ctx.stroke();

                    
                }
            });
        });
    }

    // Dibuja el grafo
    drawGraph(vertices);
}






    // Ejemplo de uso
   // const verticesJson = '[{"IdUsuario":1,"Nombres":"Alice","aristas":[{"numeroDato":2,"nombreDato":"Bob","costo":10}]},{"IdUsuario":2,"Nombres":"Bob","aristas":[{"numeroDato":3,"nombreDato":"Charlie","costo":20}]},{"IdUsuario":3,"Nombres":"Charlie","aristas":[{"numeroDato":1,"nombreDato":"Alice","costo":30}]}]';
   // mostrarGrafo(verticesJson);

