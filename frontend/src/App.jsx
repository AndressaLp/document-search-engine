import FileUpload from "./components/FileUpload"
import SearchForm from "./components/SearchForm"

function App() {
  return (
    <div className="w-full h-screen flex flex-col gap-5 items-center justify-center bg-cyan-900">
      <h1 className="text-3xl font-bold text-white mb-5">Motor de Busca em Documentos</h1>
      <FileUpload/>
      <SearchForm/>
    </div>
  )
}

export default App
