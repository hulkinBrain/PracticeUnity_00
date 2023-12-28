pipeline {
    agent any
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe"
    }
    options {
        timestamps()
        timeout(time: 5, unit: 'MINUTES')
    }
    stages {
        stage('ECHO VARS') {
            steps {
                // echo "[ECHO] ${PIPELINE_NAME} ${BRANCH_HIERARCHY}"
            }
        }
        stage('BUILD') {
            script {
                // Splitting Pipeline name and directory path/hierarchy for putting the unity build in the correct path 
                def allJob = env.JOB_NAME.tokenize('/') as String[];
                env.PIPELINE_NAME = allJob[0];
                env.BRANCH_HIERARCHY = env.JOB_NAME.substring(allJob[0].length()+1, env.JOB_NAME.length());
                
            }
            steps {
                bat "\"${UNITY_PATH}\" -nographics -batchmode -quit -executeMethod JenkinsBuild.BuildDefault ${JOB_NAME} ${JENKINS_HOME}/jobs/${PIPELINE_NAME}/branches/${BRANCH_HIERARCHY}/builds/${BUILD_NUMBER}/output"
            }
        }
        stage('TEST') {
            environment {
                PATH_TO_BALLMOVELOG = ${JENKINS_HOME}/jobs/${PIPELINE_NAME}/branches/${BRANCH_HIERARCHY}/builds/${BUILD_NUMBER}/output/BallMoveLog.txt
            }
            steps {
                bat "\"${JENKINS_HOME}/jobs/${PIPELINE_NAME}/branches/${BRANCH_HIERARCHY}/builds/${BUILD_NUMBER}/output/${JOB_NAME}.exe\" -nographics -batchmode -logMode \"${PATH_TO_BALLMOVELOG}\""
                
            }
        }
        stage('PACKAGE') {

        }
    }
}