// ** Toolkit imports
import detentoApiServices from "../api-services/detento-api-service"

// ** Axios Imports
import axios from 'axios'

interface Params {
    ipen: number
    pec: string
}

export namespace DetentoStoreService {
    // ** Atualização de PEC
    export const alterPecAsync = (params: Params) => {
        const response = axios.put(`${detentoApiServices.alterPecAsync}/${params.ipen}/${params.pec}`, {})
        return response
    }
}