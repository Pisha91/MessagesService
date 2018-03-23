class MessageService{
    constructor(url){
        this.url = url;
    }

    _getRequestOptions(data) {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');       

        return {
            method: 'POST',
            headers: headers,
            mode: 'cors',
            cache: 'default',
            body: JSON.stringify(data)
        };
    }

    sendMessage(message){
        const requestOptions = this._getRequestOptions(message);
        
        return fetch(this.url + '/api/messages/send', requestOptions);
    }
}

module.exports = MessageService;