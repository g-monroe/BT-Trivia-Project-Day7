import React, { CSSProperties } from 'react';
import { ITriviaGame } from './types/Superhero.types';
import { Card, Tag } from 'antd';
import Title from 'antd/lib/typography/Title';
import { whileStatement } from '@babel/types';

interface ISuperheroCardProps {
    superhero: ITriviaGame;
}
class SuperheroCard extends React.Component<ISuperheroCardProps> {
    render() {
        const headerStyle:CSSProperties = {
            backgroundColor: "white",
            color: "black",
            fontWeight: 'bolder',
            fontSize: 30
        }

        return (
            <Card title={this.props.superhero.Questions![0].QuestionText} bordered={true}  headStyle={headerStyle} data-testid="superhero-card">

            </Card>
        );
    }
}

export default SuperheroCard;