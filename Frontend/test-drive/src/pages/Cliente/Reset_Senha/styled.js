import styled from 'styled-components'

//index.js

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    height:100vh;
    width: 100vw;
    box-sizing:border-box;
`;

export const H1 = styled.h1`
    text-align:center;
    text-decoration:underline;

    font-size:47px;
    font-weight:400;
    font-display:oblique;

`;

export const ConteudoWrapper = styled.div`
    display:flex;
    flex-direction:column;
    height:80vh;
    width:50vw;

    box-sizing:border-box;
    margin-left:auto;
    margin-right:auto;
    align-items:center;
    justify-content:center;
`;

export const Page = styled.div`
    display:flex;
    flex-direction:column;
    height:60vh;
    width:40vw;

    box-sizing:border-box;
    padding-left:16px;
    padding-right:16px;
    border:3px solid rgb(010,015,025,0.3);
    justify-content:center;
    align-items: center;

`;

export const Span = styled.span`
    font-size:18px;
    font-weight:600;

`;