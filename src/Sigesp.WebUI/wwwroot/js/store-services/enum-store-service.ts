// ** Toolkit imports
import enumApiServices from "../api-services/enum-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace EnumStoreService {
    // ** List Enum MonthOfYearEnum
    export const listYearMonths = () => {
        const request = axios.get(enumApiServices.listYearMonths, {})
        return request
    }

    // ** List Enum Turnos
    export const listTurnos = () => {
        const request = axios.get(enumApiServices.listTurnos, {})
        return request
    }
}