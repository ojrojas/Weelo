export const toImageBase64 = async (blob:Blob): Promise<any>  =>  {
    return new Promise((resolve, reject)=>{
        const reader = new FileReader();
        reader.readAsDataURL(blob);
        reader.onloadend= () =>{
            resolve(reader.result);
        };
        reader.onerror = reject;
    } );
  };