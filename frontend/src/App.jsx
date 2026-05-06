import { useState } from "react"
import FileUpload from "./components/FileUpload"
import ResultTable from "./components/ResultTable"
import SearchForm from "./components/SearchForm"

function App() {
  const [file, setFile] = useState(null);
  const [result, setResult] = useState(null);

  const handleSearch = async (pattern, algorithm) => {
    const formData = new FormData();
    formData.append("file", file);
    formData.append("pattern", pattern);
    formData.append("algorithm", algorithm);

    const response = await api.post("/search", formData);
    setResult(response.data);
  }

  return (
    <div className="w-full h-screen flex flex-col gap-5 items-center justify-center bg-cyan-900">
      <h1 className="text-3xl font-bold text-white mb-5">Motor de Busca em Documentos</h1>
      <FileUpload setFile={setFile}/>
      <SearchForm onSearch={handleSearch}/>
      <ResultTable result={result}/>
    </div>
  )
}

export default App
