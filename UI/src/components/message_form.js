import React from 'react';
import MessageService from '../service/message_service';
import RecipientsComponent from './recipients_component'

class MessageForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            serviceUrl: '',
            subject: '',
            body: '',            
            responseText: '',
            generalError: ''
        }

        this.handleSubjectChange = this.handleSubjectChange.bind(this);
        this.handleServiceUrlChange = this.handleServiceUrlChange.bind(this);
        this.handleBodyChange = this.handleBodyChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    

    handleSubjectChange(event) {
        this.setState({ subject: event.target.value });
    }

    handleServiceUrlChange(event) {
        this.setState({ serviceUrl: event.target.value });
    }

    handleBodyChange(event) {
        this.setState({ body: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        const message = {
            Subject: this.state.subject,
            Body: this.state.body,
            RecipientIds: this.state.Recipients
        }
        const messageService = new MessageService(this.state.serviceUrl);
        messageService.sendMessage(message)
        .then(response => {
            if(response.status === 200){              
                response.json().then(id => { this.setState( { responseText: id, generalError: ''})});
            }else{
                this.setState({generalError: "Some issue occured during request!"});
            }
        })
        .catch(error => this.setState({generalError: "Some issue occured during request! Please check url!"}));
    }

    // For such purpose better to use redux in real app
    handleRecipientsUpdate = (val) => {
        this.setState({ Recipients: val });
      };

    // Also for real application should form should be splitted into components which could be reusable
    render() {
        return (
            <form onSubmit={this.handleSubmit}>            
                <div>
                    <div>Url:</div>
                    <div><input type="url" value={this.state.serviceUrl} onChange={this.handleServiceUrlChange} required /></div>
                </div>
                <div>
                    <div>Subject:</div>
                    <div><input type="text" value={this.state.subject} onChange={this.handleSubjectChange} required maxLength="100" /></div>
                </div>
                <div>
                    <div>Body:</div>
                    <div><textarea rows="4" cols="30" value={this.state.body} onChange={this.handleBodyChange} required maxLength="255" /></div>
                </div>
                <RecipientsComponent onUpdate={this.handleRecipientsUpdate} />
                <div>{this.state.responseText}</div>
                <div>{this.state.generalError}</div>
                <div><input type="submit" value="Submit" /></div>
            </form>
        );
    }
}

module.exports = MessageForm;