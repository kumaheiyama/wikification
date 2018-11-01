import React, { Component } from 'react';

export class ContentPages extends Component {
    

    static renderContentPagesTable(contentPages) {
        if (contentPages.length === 0) {
            return <div>No pages</div>
        }

        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Version</th>
                    </tr>
                </thead>
                <tbody>
                    {contentPages.map(contentPage => (
                        <tr key={contentPage.title}>
                        <td>{contentPage.title}</td>
                        <td>{contentPage.version}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    displayName = ContentPages.name

    constructor(props) {
        super(props);
        this.state = { contentPages: [], loading: true };

        fetch('api/ContentPage/GetContentPages?externalId=test1')
            .then(response => response.json())
            .then(data => {
                this.setState({ contentPages: data, loading: false });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ContentPages.renderContentPagesTable(this.state.contentPages);

        return (
            <div>
                <h1>Content pages</h1>
                {contents}
            </div>
        );
    }
}
