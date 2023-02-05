// ** Toolkit imports
import accountApiServices from "../api-services/account-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace AccountStoreService {
    // ** Get tema to user logged
    export const temaAsync = () => {
        const request = axios.get(accountApiServices.temaAsync, {})
        return request
    }

    // ** Change tema to user logged
    export const temaChangeAsync = (tema: string) => {
        const request = axios.post(`${accountApiServices.temaChangeAsync}${tema}`, {})
        return request
    }
}