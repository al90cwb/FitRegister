import { FormHandles } from "@unform/core";
import { useCallback, useRef } from "react";


export const useVForm = () =>{

    const fomrRef = useRef<FormHandles>(null);

    const isSaveAndNew = useRef(false);
    const isSaveAndClose = useRef(false);

    const handleSave = useCallback(()=> {
        isSaveAndClose.current = false;
        isSaveAndNew.current = false;
        fomrRef.current?.submitForm();
    },[]);

    const handleSaveAndNew = useCallback(()=> {
        isSaveAndClose.current = false;
        isSaveAndNew.current = true;
        fomrRef.current?.submitForm();

    },[]);

    const handleSaveAndClose = useCallback(()=> {
        isSaveAndClose.current = true;
        isSaveAndNew.current = false;
        fomrRef.current?.submitForm();

    },[]);


    
    const handleIsSaveAndNew = useCallback(()=> {
        return isSaveAndNew.current;
    },[]);

    const handleIsSaveAnsClose = useCallback(()=> {
        return isSaveAndClose.current;
    },[]);



    return{
        fomrRef,
        save: handleSave,
        saveAndNew: handleSaveAndNew,
        saveAndClose: handleSaveAndClose,

        isSaveAndNew: handleIsSaveAndNew,
        isSaveAnsClose: handleIsSaveAnsClose,

    };

};