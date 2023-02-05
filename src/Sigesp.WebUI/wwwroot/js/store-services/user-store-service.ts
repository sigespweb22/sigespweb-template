// ** Toolkit imports
import userApiServices from "../api-services/user-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace UserStoreService {
    // ** List users to select2
    export const listToSelect2 = () => {
        const request = axios.get(userApiServices.listToSelect2, {})
        return request
    }

    // ** List users to select2 servidores
    export const listToSelect2Servidores = () => {
        const request = axios.get(userApiServices.listToSelect2Servidores, {})
        return request
    }
}