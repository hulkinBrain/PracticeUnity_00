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
        stage('BUILD') {
            steps {
                bat "\"${UNITY_PATH}\" -nographics -batchmode -executeMethod JenkinsBuild.BuildDefault ${JOB_NAME} ${JENKINS_HOME}/jobs/${JOB_BASE_NAME}/builds/${BUILD_NUMBER}/output"
            }
        }
        stage('TEST') {
            steps {
                bat "\"${JENKINS_HOME}/jobs/${JOB_BASE_NAME}/builds/${BUILD_NUMBER}/output/${JOB_NAME}.exe\" -nographics -batchmode -logMode \"${PATH_TO_BALLMOVELOG}\""
            }
        }
    }
}