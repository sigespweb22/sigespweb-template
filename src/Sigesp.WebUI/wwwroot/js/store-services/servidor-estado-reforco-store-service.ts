// ** Toolkit imports
import servidorEstadoReforcoApiServices from "../api-services/servidor-estado-reforco-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace ServidorEstadoReforcoStoreService {
    // ** Delete by date
    export const deleteByDataAsync = (data: string) => {
        const request = axios.delete(servidorEstadoReforcoApiServices.deleteByDateAsync, { data: { date: data }})
        return request
    }

    // ** List With Unavailable Dates
    export const listWithUnavailableDatesAsync = (data: string) => {
        const request = axios.get(`${servidorEstadoReforcoApiServices.listWithUnavailableDatesAsync}/${data}`)
        return request
    }
}