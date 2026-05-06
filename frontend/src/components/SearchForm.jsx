import { useState } from "react";

function SearchForm({ onSearch }){
    const [pattern, setPattern] = useState("");
    const [algorithm, setAlgorithm] = useState("Naive");

    const handleSubmit = (e) => {
        e.preventDefault();
        onSearch(pattern, algorithm);
    };

    return(
        <div className="bg-white w-96 p-3 rounded-xl">
            <form onSubmit={handleSubmit} className="flex flex-col gap-3">
                <label className="font-bold">Selecione o algoritmo</label>
                <select className="cursor-pointer rounded-md p-1 outline-none bg-gray-300 hover:bg-gray-400" onChange={(e) => setAlgorithm(e.target.value)}>
                    <option value="Naive">Naive</option>
                    <option value="KMP">KMP</option>
                    <option value="RabinKarp">Rabin-Karp</option>
                    <option value="BoyerMoore">Boyer-Moore</option>
                </select>
                <label className="font-bold">Digite o texto</label>
                <input className="rounded-md p-1 outline-none bg-gray-300" type="text" placeholder="Texto a buscar" value={pattern} onChange={(e) => setPattern(e.target.value)}/>
                <button className="cursor-pointer rounded-md p-1 outline-none bg-cyan-800 hover:bg-cyan-700 text-white" type="submit">Buscar</button>
            </form>
        </div>
    )
}

export default SearchForm;