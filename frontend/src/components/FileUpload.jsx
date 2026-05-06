function FileUpload({ setFile }){
    return(
        <div className="bg-white w-96 p-3 rounded-xl">
            <h3 className="font-bold">Upload do arquivo TXT</h3>
            <input className="cursor-pointer rounded-md p-1 outline-none bg-gray-300 hover:bg-gray-400" type="file" accept=".txt" onChange={(e) => setFile(e.target.files[0])}/>
        </div>
    )
}

export default FileUpload;