// ** Toolkit imports
import notificationApiServices from "../api-services/notification-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace NotificationStoreService {
    // ** List By User logged
    export const listaAsync = () => {
        const request = axios.get(notificationApiServices.listaAsync, {})
        return request
    }

    // ** Delete By Id
    export const deleteAsync = (id: string) => {
        const request = axios.delete(`${notificationApiServices.deleteAsync}${id}`, {})
        return request
    }

    // ** Read By Id
    export const readAsync = (id: string) => {
        const request = axios.post(`${notificationApiServices.readAsync}${id}`, {})
        return request
    }
}