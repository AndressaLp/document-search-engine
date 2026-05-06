function ResultTable({ result }){
    if(!result) return null;

    return(
        <div className="bg-white w-96 p-3 rounded-xl flex flex-col gap-1">
            <h3 className="font-bold">Resultado</h3>
            <p>Encontrado: {result.found ? "Sim" : "Não"}</p>
            <p>Tempo: {result.executionTimeMs} ms</p>
            <p>Ocorrências: {result.occurrences}</p>
            <p>Posições: {result.positions.join(", ")}</p>
            <p>N (texto): {result.textSize}</p>
            <p>M (padrão): {result.patternSize}</p>
        </div>
    )
}

export default ResultTable;