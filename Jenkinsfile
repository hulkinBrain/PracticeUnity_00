pipeline {
    agent any
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe"
        PATH_TO_BALLMOVELOG = "C:\\Users\\vmpro\\Documents\\UnityProjects\\BallMoveLog.txt"
    }
    options {
        timestamps()
        timeout(time: 45, unit: 'MINUTES')
    }
    stages {
        stage('TEST') {
            steps {
                bat "echo ECHO: ${env.JOB_NAME} ${JOB_NAME}"
            }
        }
    }
}